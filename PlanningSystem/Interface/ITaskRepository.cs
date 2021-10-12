using PlanningSystemDAL.Models;
using System.Collections.Generic;

namespace PlanningSystemDAL.Interface
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAllTaskSort(string sort);
        void DeleteTask(string id);
        void AddTask(Task task);
        void UpdateTask(Task task, string taskId);
        Task GetTask(string taskId);
        IEnumerable<Task> GetAllTask();
    }
}