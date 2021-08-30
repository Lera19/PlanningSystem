using PlanningSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var result = new TaskRepository();
            Console.WriteLine("all");
            result.GetAllTask();
            Console.ReadKey();
        }
    }
}
