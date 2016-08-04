using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace PortalWeb
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class Portal
    {
        // HTTP GET을 사용하려면 [WebGet] 특성을 추가합니다. 기본 ResponseFormat은 WebMessageFormat.Json입니다.
        // XML을 반환하는 작업을 만들려면
        //     [WebGet(ResponseFormat=WebMessageFormat.Xml)]을 추가하고
        //     다음 줄을 작업 본문에 포함시킵니다.
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // 여기에 작업 구현을 추가합니다.
            return;
        }

        // 여기에 작업을 추가하고 해당 작업을 [OperationContract]로 표시합니다.
    }
}
