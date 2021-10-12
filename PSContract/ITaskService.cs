using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PSContract
{
    [ServiceContract]
    public interface ITaskService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "tasks", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CreateTask(TaskApi task);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "tasks/{taskId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool UpdateTask(string taskId, TaskApi task);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "tasks/{taskId}", ResponseFormat = WebMessageFormat.Json)]
        bool DeleteTask(string taskId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "tasks/{taskId}", ResponseFormat = WebMessageFormat.Json)]
        TaskApi GetTask(string taskId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "tasks{sort}", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<TaskApi> GetAllTask(string sort);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "tasksChangeStatus", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool ChangeOfStatusFirstMethod();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "tasksChangeStatusSecond", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool ChangeOfStatusSecondMethod();
    }
}