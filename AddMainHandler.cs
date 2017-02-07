using SharpShell.SharpIconOverlayHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SharpShell.Interop;
using System.Drawing;
using System.IO;
using System.Xml;
using SRCommon.Controller.FileRepositoryAgent.XmlProcess;
using SRCommon.Models.FileRepository;
using SharpShell.Attributes;
using SharpShell.ServerRegistration;
using Microsoft.Win32;
using System.Security.AccessControl;

[ComVisible(true)]
class AddMainHandler : SharpIconOverlayHandler
{
    protected override Icon GetOverlayIcon()
    {
        return SRSCCADD.Properties.Resource.file_add_256;
    }

    protected override int GetPriority()
    {
        return 3;
    }

    protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
    {
        try
        {
            string pathType = "File";
            if ((attributes & FILE_ATTRIBUTE.FILE_ATTRIBUTE_DIRECTORY) != 0)
            {
                pathType = "Dir";
            }

            return CheckingPath(path, pathType);
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool CheckingPath(string path, string pathType)
    {
        string cloneFolderPath = "C:\\ECA\\files\\shellExtends\\iconoverlay";
        if (Directory.Exists(cloneFolderPath))
        {
            if (Directory.GetFiles(cloneFolderPath).ToList().Count == 0)
            {
                return false;
            }
            DirectoryInfo dir = new DirectoryInfo(cloneFolderPath);
            FileInfo cloneFile = null;
            int i = 0;
            foreach (var file in dir.GetFiles())
            {
                if (i == 0)
                {
                    cloneFile = file;
                    i++;
                    continue;
                }
                else
                {
                    if (cloneFile.CreationTime < file.CreationTime)
                    {
                        cloneFile = file;
                    }
                }
            }

            XmlDocument xml = new XmlDocument();
            xml.Load(cloneFile.FullName);

            foreach (XmlElement element in xml.GetElementsByTagName("clonePath"))
            {
                String clonePath = element.Attributes["Path"]?.Value.ToString();
                clonePath = clonePath.Substring(0, clonePath.LastIndexOf('\\'));
                if (clonePath.Split('\\').Count() <= path.Split('\\').Count())
                {
                    if (clonePath.Split('\\').Count() <= 2)
                    {
                        var resultClonePath = clonePath.Remove(0, clonePath.LastIndexOf('\\')+1);
                        var resultPath = path.Remove(0, Path.GetDirectoryName(clonePath).Length).Split('\\').ElementAt(0);
                        if (resultPath.Equals(resultClonePath))
                        {
                            return IconChecking(path, element.Attributes["Path"]?.Value.ToString(), pathType);
                        }
                    }
                    else
                    {
                        var resultClonePath = clonePath.Remove(0, clonePath.LastIndexOf('\\') + 1);
                        var resultPath = path.Remove(0, Path.GetDirectoryName(clonePath).Length + 1).Split('\\').ElementAt(0);
                        if (resultPath.Equals(resultClonePath))
                        {
                            return IconChecking(path, element.Attributes["Path"]?.Value.ToString(), pathType);
                        }
                    }
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }





    private bool IconChecking(string nowPath, string silkroadPath, string pathType)
    {
        int temp = silkroadPath.Substring(0, silkroadPath.LastIndexOf('\\')).Length + 1;
        string localPath = silkroadPath.Substring(0, silkroadPath.LastIndexOf('\\'));
        var serverXml = new XmlMaster(localPath, new ServerXml());
        var serverFileList = serverXml.GetListByType(typeof(DFile));
        bool flag = true;
        if (pathType.CompareTo("Dir") == 0)
        {
            DirectoryInfo addDir = new DirectoryInfo(nowPath);
            if (addDir.Name.CompareTo(".silkroad") == 0)
            {
                return false;
            }
            return false;
        }
        else
        {
            FileInfo addFile = new FileInfo(nowPath);
            if (addFile.FullName.Contains(".silkroad"))
            {
                return false;
            }
            serverFileList.ForEach(server =>
            {
                if (server.Root.Equals(addFile.FullName.Remove(0, temp)))
                {
                    flag = false;
                }
            });
            return flag;
        }

    }


    /// <summary>
    /// The custom registration function.
    /// </summary>
    /// <param name="serverType">Type of the server.</param>
    /// <param name="registrationType">Type of the registration.</param>
    [CustomRegisterFunction]
    internal static void CustomRegisterFunction(Type serverType, RegistrationType registrationType)
    {
        //  Open the local machine.
        using (var localMachineBaseKey = registrationType == RegistrationType.OS64Bit
            ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64) :
              RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
        {
            //  Open the ShellIconOverlayIdentifiers.
            using (var overlayIdentifiers = localMachineBaseKey
                .OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers",
                RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.EnumerateSubKeys | RegistryRights.QueryValues | RegistryRights.CreateSubKey | RegistryRights.CreateSubKey))
            {
                //  If we don't have the key, we've got a problem.
                if (overlayIdentifiers == null)
                    throw new InvalidOperationException("Cannot open the ShellIconOverlayIdentifiers key.");

                //  How many shell icon overlay identifiers do we have?
                var overlayHandlersCount = overlayIdentifiers.GetSubKeyNames().Count();
                if (overlayHandlersCount >= 20)
                    Console.Error.WriteLine("There are already the maximum number of overlay handlers registered for the system. Although '{0}' is being registered, it might not be used by Windows Explorer.");

                //  Create the overlay key.
                using (var overlayKey = overlayIdentifiers.CreateSubKey("   " + serverType.Name))
                {
                    //  If we don't have the overlay key, we've got a problem.
                    if (overlayKey == null)
                        throw new InvalidOperationException("Cannot create the key for the overlay server.");

                    //  Set the server CLSID.
                    overlayKey.SetValue(null, "{" + serverType.GUID.ToString() + "}");
                }
            }
        }
    }

    /// <summary>
    /// Customs the unregister function.
    /// </summary>
    /// <param name="serverType">Type of the server.</param>
    /// <param name="registrationType">Type of the registration.</param>
    [CustomUnregisterFunction]
    internal static void CustomUnregisterFunction(Type serverType, RegistrationType registrationType)
    {
        //  Open the local machine.
        using (var localMachineBaseKey = registrationType == RegistrationType.OS64Bit
            ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64) :
              RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
        {
            //  Open the ShellIconOverlayIdentifiers.
            using (var overlayIdentifiers = localMachineBaseKey
                .OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers",
                RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.Delete | RegistryRights.EnumerateSubKeys | RegistryRights.ReadKey))
            {
                //  If we don't have the key, we've got a problem.
                if (overlayIdentifiers == null)
                    throw new InvalidOperationException("Cannot open the ShellIconOverlayIdentifiers key.");

                //  Delete the overlay key.
                if (overlayIdentifiers.GetSubKeyNames().Any(skn => skn == "   " + serverType.Name))
                {
                    Console.Out.WriteLine("Removing '{0}'", "   " + serverType.Name);
                    overlayIdentifiers.DeleteSubKey("   " + serverType.Name);
                }
                else
                {
                    throw new Exception(string.Format("Key '{0}' not found!", "   " + serverType.Name));
                }
            }
        }
    }
}

