using System;
using System.Linq;
using TaskServicePS;

namespace SortedTasksInPlanningSystem
{
    public class SortedTasks
    {
        private TaskService _taskService = new TaskService();
        
        public void SortedByPriority()
        {
            var date = _taskService.GetAllTask();
            var result = date.OrderBy(c => c.Priority).ToList();
            foreach(var a in result)
            {
                Console.WriteLine($"{a.Id}, {a.Name}, {a.Priority}, {a.StatusTask}, {a.DateTimeAddeed}, {a.Description}");
            }
        }

        public void SortedByStatus()
        {
            var date = _taskService.GetAllTask();
            var result = date.OrderByDescending(c => c.StatusTask).ToList();
            foreach (var a in result)
            {
                Console.WriteLine($"{a.Id}, {a.Name}, {a.Priority}, {a.StatusTask}, {a.DateTimeAddeed}, {a.Description}");
            }
        }

        public void SortedById()
        {
            var date = _taskService.GetAllTask();
            var result = date.OrderBy(c => c.Id).ToList();
            foreach (var a in result)
            {
                Console.WriteLine($"{a.Id}, {a.Name}, {a.Priority}, {a.StatusTask}, {a.DateTimeAddeed}, {a.Description}");
            }
        }

        public void SortedByDateTime()
        {
            var date = _taskService.GetAllTask();
            var result = date.OrderBy(c => c.DateTimeAddeed).ToList();
            foreach (var a in result)
            {
                Console.WriteLine($"{a.Id}, {a.Name}, {a.Priority}, {a.StatusTask}, {a.DateTimeAddeed}, {a.Description}");
            }
        }
    }
}
