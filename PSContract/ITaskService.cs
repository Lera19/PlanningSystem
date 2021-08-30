using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace PSContract
{
    [ServiceContract]
    public interface ITaskService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "task", RequestFormat = WebMessageFormat.Json)]
        void CreateTask(TaskApi task);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "task/{taskId}", RequestFormat = WebMessageFormat.Json)]
        void UpdateTask(string taskId, TaskApi task);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "task/{taskId}")]
        void DeleteTask(string taskId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "task/{taskId}", ResponseFormat = WebMessageFormat.Json)]
        TaskApi GetTask(string taskId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "task", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<TaskApi> GetAllTask();


    }
}
