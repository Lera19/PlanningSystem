using PlanningSystem;
using PlanningSystem.Interface;
using PSContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using TaskServicePS;

namespace HostPS
{
    public class ApplicationContext
    {
        public ApplicationContext()
        {
            TaskRepository = new TaskRepository();
            TaskService = new TaskService();
            ServiceHost = new ServiceHost(TaskService);
        }
        public ServiceHost ServiceHost { get; }
        public ITaskService TaskService { get; }
        public ITaskRepository TaskRepository { get; }
    }
}
