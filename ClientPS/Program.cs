using Newtonsoft.Json;
using PSContract;
using System;
using System.Linq;
using TaskServicePS;

namespace ClientPS
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ALL");
            var client = new TaskService();
            var resultAll = client.GetAllTask();
            Console.WriteLine(JsonConvert.SerializeObject(resultAll, Formatting.Indented));

            Console.WriteLine("\n\nRemove");
            client.DeleteTask(resultAll.First().Id);
            resultAll = client.GetAllTask();

            Console.WriteLine(JsonConvert.SerializeObject(resultAll, Formatting.Indented));


            Console.WriteLine("\n\nAdd");
            var taskApi = new TaskApi() { Id = Guid.NewGuid().ToString(), Name = "Cooking4", DateTimeAddeed = DateTime.Today, Priority = Priorities.High, StatusTask = Statuses.Ready };
            client.CreateTask(taskApi);
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
                DateTimeAddeed= resultAll.First().DateTimeAddeed,
                Priority= resultAll.First().Priority
            };
            client.UpdateTask(updated, taskUpdate);
            Console.WriteLine(JsonConvert.SerializeObject(client.GetTask(updated), Formatting.Indented));

            Console.ReadKey();
        }
    }
}
