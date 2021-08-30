using AutoMapper;
using PlanningSystem;
using PlanningSystem.Interface;
using PlanningSystemDAL.Models;
using PSContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace TaskServicePS
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
         InstanceContextMode = InstanceContextMode.Single)]
    public class TaskService : ITaskService
    {
        //public TaskService() { }
        private readonly Mapper _mapper;
        private readonly ITaskRepository _taskRepository;
        public TaskService()
        {
            _taskRepository = new TaskRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskApi>();
                cfg.CreateMap<TaskApi, Task>();
            });
            _mapper = new Mapper(config);
        }
        

        public void CreateTask(TaskApi task)
        {
            var map = _mapper.Map<Task>(task);
            _taskRepository.AddTask(map);
        }

        public void DeleteTask(string taskId)
        {
            _taskRepository.DeleteTask(taskId);
        }

        public IEnumerable<TaskApi> GetAllTask()
        {
            var rep = _taskRepository.GetAllTask();
            var map = _mapper.Map<IEnumerable<TaskApi>>(rep);
            return map;
        }

        public TaskApi GetTask(string taskId)
        {
            var map = _mapper.Map<TaskApi>(_taskRepository.GetTask(taskId));
            return map;
        }

        public void UpdateTask(string taskId, TaskApi task)
        {
            var map = _mapper.Map<Task>(task);
                _taskRepository.UpdateTask(map, taskId);

        }
    }
}
