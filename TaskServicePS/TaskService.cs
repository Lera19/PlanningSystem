using AutoMapper;
using NLog;
using PlanningSystemDAL;
using PlanningSystemDAL.Interface;
using PlanningSystemDAL.Models;
using PSContract;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace TaskServicePS
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
         InstanceContextMode = InstanceContextMode.Single)]
    public class TaskService : ITaskService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
            try
            {
                logger.Debug("Create task method start");
                var map = _mapper.Map<Task>(task);
                _taskRepository.AddTask(map);
                var error = new Exception();

                logger.Info("Create success. finish method CreateTask");
            }
            catch (Exception ex)
            {
                logger.Error($"Exception in create {ex.Message}");
            }
        }

        public void DeleteTask(string taskId)
        {
            try
            {
                logger.Debug("Delete task method start");
                _taskRepository.DeleteTask(taskId);
                logger.Info("Delete success. finish method DeleteTask");
            }
            catch (Exception ex)
            {
                logger.Error($"Exception in delete {ex.Message}");
            }

        }

        public IEnumerable<TaskApi> GetAllTask()
        {
            try
            {
                logger.Debug("Get all task method start");
                var rep = _taskRepository.GetAllTask();
                var map = _mapper.Map<IEnumerable<TaskApi>>(rep);
                logger.Info("Success method. finith method GetAllTask");
                return map;

            }
            catch (Exception ex)
            {
                logger.Error($"Exception in getalltask {ex.Message}");
                return null;
            }
        }

        public TaskApi GetTask(string taskId)
        {
            try
            {
                logger.Debug("Get task method start");
                var map = _mapper.Map<TaskApi>(_taskRepository.GetTask(taskId));
                logger.Info("Success method. finish method GetTask");
                return map;
            }
            catch (Exception ex)
            {
                logger.Error($"Exception in gettask {ex.Message}");
                return null;
            }

        }

        public void UpdateTask(string taskId, TaskApi task)
        {
            try
            {
                logger.Debug("Update method");
                var map = _mapper.Map<Task>(task);
                _taskRepository.UpdateTask(map, taskId);
                logger.Info("Success method update");
            }
            catch (Exception ex)
            {
                logger.Error($"Exception in update {ex.Message}");
            }


        }
    }
}
