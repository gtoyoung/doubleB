using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PortalService
{
    [ServiceContract]
    public interface IPortal
    {
        [OperationContract]

        [WebGet(UriTemplate = "/GetData",BodyStyle =WebMessageBodyStyle.Wrapped,RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<CompanyTable> GridPortlet();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Company", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddCompany(CompanyContract company);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/DeleteCompany", ResponseFormat = WebMessageFormat.Json)]
        void DeleteCompany(CompanyContract company);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/UpdateCompany", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void UpdateCompany(CompanyContract company);
    }
}
