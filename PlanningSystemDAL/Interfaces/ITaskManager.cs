using PlanningSystemBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanningSystemDAL.Interfaces
{
   public  interface ITaskManager 
    {
        IList<TaskModel> GetTasks();
        void AddTask(TaskModel taskModel);
        void UpdateTask(TaskModel taskModel);
        void DeleteTask(int id);
    }
}
