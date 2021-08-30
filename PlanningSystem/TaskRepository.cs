using PlanningSystem.Interface;
using PlanningSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;

namespace PlanningSystem
{
    public class TaskRepository : ITaskRepository
    {
        public IList<Task> GetTasks()
        {
            using(var context = new TaskContext())
            {
                var result = context.Task.ToList();
                return result;

            }
        }
        public void AddTask(Task task)
        {
            using(var context = new TaskContext())
            {
                context.Task.Add(task);
                context.SaveChanges();
            }
        }
        public void DeleteTask(string id)
        {
            using(var context = new TaskContext())
            {
                var t = context.Task.First(c=>c.ID==id);
                if (t != null)
                {
                    // var t = context.Task.Where(x => x.ID == id).SingleOrDefault<Task>();
                    context.Task.Remove(t);
                    context.SaveChanges();
                    
                }
                else
                {
                    Console.WriteLine("This task not found");
                }

            }
        }

        public IEnumerable<Task> GetAllTask()
        {
            using (var context = new TaskContext())
            {
                return context.Task.ToList();
            }
        }

        public void UpdateTask(Task task, string taskId)
        {
            using (var context = new TaskContext())
            {
                var taskResult = context.Task.First(c => c.ID == taskId);
                context.Task.Remove(taskResult);
                context.Task.Add(task);
                context.SaveChanges();
            }
           
        }

        public Task GetTask(string taskId)
        {
            using(var context = new TaskContext())
            {
                return context.Task.First(c => c.ID == taskId);
            }
            
        }
    }
}
