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
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking1", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Medium, StatusTask = StatusesForTask.ToDo , Description="cooking1fjngyhnj", StatusesForRejection=StatusesForRejection.Processing},
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking2", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Medium, StatusTask = StatusesForTask.InProgress, Description = "cooking2fjngyhnj" , StatusesForRejection=StatusesForRejection.Processing},
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking3", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = StatusesForTask.InProgress, StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking4", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = StatusesForTask.ToDo, StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking5", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = StatusesForTask.ToDo, StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking6", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryHigh, StatusTask = StatusesForTask.Completed, StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking7", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryLow, StatusTask = StatusesForTask.Completed, StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking8", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryHigh, StatusTask = StatusesForTask.Ready,StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking9", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryLow, StatusTask = StatusesForTask.InProgress,StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking10", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Low, StatusTask = StatusesForTask.Ready,StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking11", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.High, StatusTask = StatusesForTask.Completed,StatusesForRejection=StatusesForRejection.Processing },
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking12", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.VeryLow, StatusTask = StatusesForTask.ToDo ,StatusesForRejection=StatusesForRejection.Processing},
                new Task() {Id=Guid.NewGuid().ToString(),  Name = "Cooking13", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Low, StatusTask = StatusesForTask.Ready ,StatusesForRejection=StatusesForRejection.Processing}
        };

            context.Task.AddRange(tasks);
            context.SaveChanges();
        }
    }
}