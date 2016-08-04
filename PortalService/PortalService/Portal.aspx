<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portal.aspx.cs" Inherits="PortalWeb.Portal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Portal Layout Sample</title>
    <link rel="stylesheet" type="text/css" href="css/portal.css" />
    <link rel="stylesheet" type="text/css" href="css/ext-all-gray-debug.css" />
    <link rel="stylesheet" type="text/css" href="css/ext-theme-gray-all-debug.css" />

    <script type="text/javascript" src="js/ext-all.js"></script>
    <script type="text/javascript" src="js/ext-theme-gray.js"></script>

    <script type="text/javascript" src="js/examples.js"></script>
    <script type="text/javascript">
        Ext.Loader.setPath('Ext.app', 'classes');
    </script>
    <script type="text/javascript" src="js/portal.js"></script>
    <script type="text/javascript">
        Ext.require([
            'Ext.layout.container.*'
            , 'Ext.resizer.Splitter'
            , 'Ext.fx.target.Element'
            , 'Ext.fx.target.Component'
            , 'Ext.window.Window'
            , 'Ext.app.Portlet'
            , 'Ext.app.PortalColumn'
            , 'Ext.app.PortalPanel'
            , 'Ext.app.Portlet'
            , 'Ext.app.PortalDropZone'
            , 'Ext.app.GridPortlet'
            , 'Ext.app.ChartPortlet'
        ]);
        Ext.onReady(function () {
            Ext.create('Ext.app.Portal');
        });
    </script>
    <!-- </x-compile> -->
</head>

<body>

    <span id="app-msg" style="display: none;"></span>

</body>

</html>
