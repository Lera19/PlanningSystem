using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PSContract
{
    [ServiceContract]
    public interface ITaskService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "tasks", RequestFormat = WebMessageFormat.Json)]
        void CreateTask(TaskApi task);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "tasks/{taskId}", RequestFormat = WebMessageFormat.Json)]
        void UpdateTask(string taskId, TaskApi task);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "tasks/{taskId}")]
        void DeleteTask(string taskId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "tasks/{taskId}", ResponseFormat = WebMessageFormat.Json)]
        TaskApi GetTask(string taskId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "tasks", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<TaskApi> GetAllTask();
    }
}