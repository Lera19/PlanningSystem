using PlanningSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PlanningSystemDAL
{
    public class Initializer : CreateDatabaseIfNotExists<TaskContext>
    {
        protected override void Seed(TaskContext context)
        {
            var tasks = new List<Task>()
            {
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking1", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Medium, StatusTask = Statuses.ToDo , Description="cooking1fjngyhnj"},
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking2", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Medium, StatusTask = Statuses.InProgress, Description = "cooking2fjngyhnj" },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking3", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.InProgress },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking4", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.ToDo },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking5", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.ToDo },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking6", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryHigh, StatusTask = Statuses.Completed },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking7", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryLow, StatusTask = Statuses.Completed },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking8", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryHigh, StatusTask = Statuses.Ready },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking9", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryLow, StatusTask = Statuses.InProgress },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking10", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Low, StatusTask = Statuses.Ready },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking11", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = Statuses.Completed },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking12", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryLow, StatusTask = Statuses.ToDo },
                new Task() {ID=Guid.NewGuid().ToString(),  Name = "Cooking13", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Low, StatusTask = Statuses.Ready }
        };

            context.Task.AddRange(tasks);
            context.SaveChanges();
        }
    }
}