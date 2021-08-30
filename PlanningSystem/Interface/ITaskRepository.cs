using PlanningSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PlanningSystem.Interface
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAllTask();
        void DeleteTask(string id);
        void AddTask(Task task);
        void UpdateTask(Task task, string taskId);
        Task GetTask(string taskId);
    }
}
