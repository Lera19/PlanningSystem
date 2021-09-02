using Newtonsoft.Json;
using PSContract;
using SortedTasksInPlanningSystem;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ClientPS
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            ChannelFactory<ITaskService> factory = new ChannelFactory<ITaskService>(new WebHttpBinding(),
                new EndpointAddress("http://" + "localhost:44301/TaskService"));
            factory.Endpoint.Behaviors.Add(new WebHttpBehavior());

            ITaskService client = factory.CreateChannel();


            Console.WriteLine("ALL");
            var resultAll = client.GetAllTask();
            Console.WriteLine(JsonConvert.SerializeObject(resultAll, Formatting.Indented));

            Console.WriteLine("\n\nRemove");
            client.DeleteTask(resultAll.First().Id);
            resultAll = client.GetAllTask();

            Console.WriteLine(JsonConvert.SerializeObject(resultAll, Formatting.Indented));


            Console.WriteLine("\n\nAdd");
            var taskApi = new TaskApi() { Id = Guid.NewGuid().ToString(), Name = "Cooking100", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.Ready };
            client.CreateTask(taskApi);
            var taskApi2 = new TaskApi() { Id = Guid.NewGuid().ToString(), Name = "Cooking100", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.ToDo };
            client.CreateTask(taskApi2);
            var taskApi3 = new TaskApi() { Id = Guid.NewGuid().ToString(), Name = "Cooking100", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.ToDo };
            client.CreateTask(taskApi3);
            var taskApi4 = new TaskApi() { Id = Guid.NewGuid().ToString(), Name = "Cooking100", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.ToDo };
            client.CreateTask(taskApi4);
            var taskApi5 = new TaskApi() { Id = Guid.NewGuid().ToString(), Name = "Cooking100", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.ToDo };
            client.CreateTask(taskApi5);
            var taskApi6 = new TaskApi() { Id = Guid.NewGuid().ToString(), Name = "Cooking100", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.ToDo };
            client.CreateTask(taskApi6);
           
            resultAll = client.GetAllTask();
            Console.WriteLine(JsonConvert.SerializeObject(resultAll, Formatting.Indented));

            Console.WriteLine("\n\nUpdate");
            var updated = resultAll.First().Id;
            var taskUpdate = new TaskApi()
            {
                StatusTask = resultAll.First().StatusTask,
                Id = resultAll.First().Id,
                Name = resultAll.First().Name,
                Description = "New description for this task",
                DateTimeAddeed = resultAll.First().DateTimeAddeed,
                Priority = resultAll.First().Priority
            };
            client.UpdateTask(updated, taskUpdate);
            Console.WriteLine(JsonConvert.SerializeObject(client.GetTask(updated), Formatting.Indented));

            var sorted = new SortedTasks();

            Console.WriteLine("Sort date");
            sorted.SortedByDateTime();

            Console.WriteLine("Sort id");
            sorted.SortedById();

            Console.WriteLine("Sort prio");
            sorted.SortedByPriority();

            Console.WriteLine("Sort stat");
            sorted.SortedByStatus();

            Console.WriteLine("Status chenge");
            var status = new TaskServicePS.StatusChanged();
            status.ChangeOfStatus();

            Console.ReadKey();
  
        }
    }
}