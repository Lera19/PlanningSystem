using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PSContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf" in both code and config file together.
    [ServiceContract]
    public interface IRejectionService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "rejTask/{i}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool TimerForRejection(string i);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Rej", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<TaskApi> GetAllTaskForRejection();

    }
    
}
