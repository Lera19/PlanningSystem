using PlanningSystemDAL.Interface;
using PlanningSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace PlanningSystemDAL
{
    public class TaskRepository : ITaskRepository
    {
        public IList<Task> GetTasks()
        {
            using (var context = new TaskContext())
            {
                try
                {
                    var result = context.Task.ToList();
                    return result;
                }
                catch
                {
                    return null;
                }
                

            }
        }
        public void AddTask(Task task)
        {
            using (var context = new TaskContext())
            {
                try
                {
                    context.Task.Add(task);
                    context.SaveChanges();
                }
                catch(DbEntityValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void DeleteTask(string id)
        {
            using (var context = new TaskContext())
            {
                
                try
                {
                    var t = context.Task.First(c => c.Id == id);
                    context.Task.Remove(t);
                    context.SaveChanges();

                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("This task not found" + ex.Message);
                }
            }
        }

        public IEnumerable<Task> GetAllTaskSort(string sort)
        {
            using (var context = new TaskContext())
            {
                switch (sort)
                {
                    case "Priority":
                        return context.Task.OrderBy(c=>c.Priority).ToList();
                    case "Status":
                        return context.Task.OrderBy(c => c.StatusTask).ToList();
                    case "DateTime":
                        return context.Task.OrderByDescending(c => c.DateTimeAddeed).ToList();
                    case "Id":
                        return context.Task.OrderBy(c => c.Id).ToList();
                    default:
                        throw new Exception("Not found data");     
                }
            }  
        }

        public IEnumerable<Task> GetAllTask()
        {
            using(var context = new TaskContext())
            {
                return context.Task.ToList();
            }
        }

        public void UpdateTask(Task task, string taskId)
        {
            using (var context = new TaskContext())
            {
                try
                {
                    var taskResult = context.Task.First(c => c.Id == taskId);
                    context.Task.Remove(taskResult);
                    context.Task.Add(task);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public Task GetTask(string taskId)
        {
            using (var context = new TaskContext())
            {
                try
                {
                    return context.Task.First(c => c.Id == taskId);
                }
                catch
                {
                    return null;
                }
            }

        }
    }
}