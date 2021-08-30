using PlanningSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PlanningSystem
{
    public class Initializer : CreateDatabaseIfNotExists<TaskContext>
    {
        protected override void Seed(TaskContext context)
        {
           var tasks = new List<Task>()
            {
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking1", DateTimeAddeed = DateTime.Today, Priority = Priorities.Medium, StatusTask = Statuses.ToDo , Description="cooking1fjngyhnj"},
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking2", DateTimeAddeed = DateTime.Today, Priority = Priorities.Medium, StatusTask = Statuses.ToDo, Description = "cooking2fjngyhnj" },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking3", DateTimeAddeed = DateTime.Today, Priority = Priorities.Medium, StatusTask = Statuses.ToDo }
        };

            context.Task.AddRange(tasks);
            context.SaveChanges();
        }
    }
}
