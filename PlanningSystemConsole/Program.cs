using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningSystemConsole
{
    class Program
    {
        static async void Main(string[] args)
        {
            //await FirstTask();
        }

        //public static async Task FirstTask()
        //{
        //    await Task.Factory.StartNew(() =>
        //          {
        //              Console.WriteLine($"Running first task {Task.CurrentId}");
        //              Console.WriteLine("Launching child tasks");
        //              for (var i = 1; i <= 3; i++)
        //              {
        //                  var index = i;
        //                  Task.Factory.StartNew(async value =>
        //                  {
        //                      Console.WriteLine($"   Attached child task #{value} running");
        //                      await Task.Delay(500);
        //                  }, index, TaskCreationOptions.AttachedToParent);
        //              }
        //              Console.WriteLine("Finished child tasks...");
        //          }).ContinueWith( first =>
        //            Console.WriteLine($"Executing continuation of Task {first.Id}"));
        //}
    }
}
