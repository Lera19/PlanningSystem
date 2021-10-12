using AutoMapper;
using NLog;
using PlanningSystemDAL;
using PlanningSystemDAL.Interface;
using PlanningSystemDAL.Models;
using PSContract;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public bool CreateTask(TaskApi task)
        {
            try
            {
                logger.Debug("Create task method start");
                var map = _mapper.Map<Task>(task);
                _taskRepository.AddTask(map);

                logger.Info("Create success. finish method CreateTask");
                return true;
            }
            catch (Exception ex)
            {
                logger.Error($"Exception in create {ex.Message}");
                return false;
            }
        }

        public bool DeleteTask(string taskId)
        {
            try
            {
                logger.Debug("Delete task method start");
                _taskRepository.DeleteTask(taskId);
                logger.Info("Delete success. finish method DeleteTask");
                return true;
            }
            catch (Exception ex)
            {
                logger.Error($"Exception in delete {ex.Message}");
                return false;
            }

        }

        public IEnumerable<TaskApi> GetAllTask(string sort)
        {
            try
            {
                logger.Debug("Get all task method start");
                var rep = _taskRepository.GetAllTaskSort(sort.ToString());
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

        public bool UpdateTask(string taskId, TaskApi task)
        {
            try
            {
                logger.Debug("Update method");
                var map = _mapper.Map<Task>(task);
                _taskRepository.UpdateTask(map, taskId);
                logger.Info("Success method update");
                return true;
            }
            catch (Exception ex)
            {
                logger.Error($"Exception in update {ex.Message}");
                return false;
            }


        }

        public bool ChangeOfStatusFirstMethod()
        {
            logger.Debug("Change status start");
            try
            {
                using (var context = new TaskContext())
                {
                    logger.Info("Status change when status = todo");
                    var todo = context.Task.Where(i => i.StatusTask == StatusesForTask.ToDo).ToList();
                    foreach (var i in todo)
                    {
                        i.StatusTask = StatusesForTask.Ready;
                        logger.Info("ready change");
                    }
                    logger.Info("Status change when status = ready");
                    var todo1 = context.Task.Where(i => i.StatusTask == StatusesForTask.Ready).ToList();
                    foreach (var i in todo1)
                    {
                        i.StatusTask = StatusesForTask.InProgress;
                        logger.Info("ready change");
                    }
                    logger.Info("Status change when status = inprogress");
                    var todo3 = context.Task.Where(i => i.StatusTask == StatusesForTask.InProgress).ToList();
                    foreach (var i in todo3)
                    {
                        i.StatusTask = StatusesForTask.Completed;
                        logger.Info("ready change");
                    }
                    var todo4 = context.Task.Where(i => i.StatusTask == StatusesForTask.Completed);
                    Console.WriteLine($"Status completed have {todo4.Count()} task");
                    logger.Info("Status Completed");
                    context.SaveChanges();
                }

                logger.Debug("Change status finish");
                return true;
            }

            catch (Exception ex)
            {
                logger.Error($"Error change status {ex.Message}");
                return false;
            }
        }

        public bool ChangeOfStatusSecondMethod()
        {
            logger.Debug("Change status start");
            Enum[] statusArray = new Enum[5];
            statusArray[1] = StatusesForTask.ToDo;
            statusArray[2] = StatusesForTask.Ready;
            statusArray[3] = StatusesForTask.InProgress;
            statusArray[4] = StatusesForTask.Completed;

            try
            {

                using (var context = new TaskContext())
                {
                    int j = 0;
                    j++;
                    var statusForLinq = (StatusesForTask)Enum.Parse(typeof(StatusesForTask), statusArray[4].ToString());
                    var todo3 = context.Task.Where(i => i.StatusTask != statusForLinq).ToList();
                    logger.Info("count" + todo3.Count + "statforlinq" + statusForLinq.ToString());
                    foreach (var i in todo3)
                    {
                        i.StatusTask = (StatusesForTask)Enum.Parse(typeof(StatusesForTask), statusArray[j+1].ToString());
                        logger.Info("ready change" + i.StatusTask + statusArray[j + 1]);
                    }

                    logger.Info("Status change when status = ready");
                    var todo4 = context.Task.Where(c => c.StatusTask == StatusesForTask.Completed).ToList();
                    Console.WriteLine($"Status completed have {todo4.Count()} task");
                    logger.Info("Status Completed");
                    context.SaveChanges();
                }

                logger.Debug("Change status finish");
                return true;
            }

            catch (Exception ex)
            {
                logger.Error($"Error change status {ex.Message}");
                return false;
            }
        }
    }
}
