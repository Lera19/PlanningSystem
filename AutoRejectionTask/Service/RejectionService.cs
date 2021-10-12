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
using System.Threading;

namespace AutoRejectionTask.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
       InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf" in both code and config file together.
    public class RejectionService : IRejectionService
    {
        private List<TaskApi> listForReejection;
        public RejectionService()
        {
            _taskRepository = new TaskRepository();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskApi>();
                cfg.CreateMap<TaskApi, Task>();
            });
            _mapper = new Mapper(config);
        }
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly Mapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public void AutoRejection(Object obj)
        {
            try
            {
                _logger.Debug("Delete task method started");
                _logger.Info("Delete task method started");
                DateTime dateTimeSettings = DateTime.Now.ToUniversalTime().AddMinutes(-3);
                using (var context = new TaskContext())
                {
                    _logger.Info("using context");
                    listForReejection = new List<TaskApi>();
                    var date = context.Task.Any(i => i.DateTimeAddeed < dateTimeSettings);
                    _logger.Info("date=\t" + date.ToString());
                    var rej = context.Task.Where(i => i.StatusTask == StatusesForTask.ToDo).ToList();
                    _logger.Info("rej=\t" + rej.Count());

                    if (rej.Count != 0 && date == true)
                    {
                        _logger.Info("rej.Count!= 0");

                        foreach (var i in rej)
                        {

                            i.StatusesForRejection = StatusesForRejection.SendToRejection;
                                
                        }
                            _logger.Info("for");
                            context.SaveChanges();
                        _logger.Info("SaveChanges");
                        foreach (var i in rej)
                        {
                            listForReejection.Add(new TaskApi()
                            {
                                Id = i.Id,
                                DateTimeAddeed = i.DateTimeAddeed,
                                Description = i.Description,
                                Name = i.Name,
                                Priority = i.Priority,
                                StatusTask = i.StatusTask,
                                StatusesForRejection = StatusesForRejection.SendToRejection

                            });
                        }
                        _logger.Info("taskSentToRej" + "listForReejection" + listForReejection.Count());

                        _logger.Info("Add task in rejection list for will delete");
                        var taskSendTpRej = context.Task.Where(c => c.StatusesForRejection == StatusesForRejection.SendToRejection).ToList();
                        _logger.Info("taskSendTpRej" + taskSendTpRej.Count());
                        if (taskSendTpRej.Count != 0)
                        {
                            _logger.Info("foreach ..");
                            foreach (var i in listForReejection)
                            {
                                i.StatusesForRejection = StatusesForRejection.Deleted;
                            }
                            _logger.Info("Status task update on deleted");
                        }
                       
                    }
                    else
                    {
                        _logger.Error("Exception Not found task \n");
                        Console.WriteLine("Not found task");
                       
                       

                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error($"Exception in getalltask {ex.Message}");
           
            }
        }

        public bool TimerForRejection(string i)
        {
            while (true)
            {
                _logger.Debug("Method reject open");
                try
                {
                    int outNumber;
                    bool a = int.TryParse(i, out outNumber);
                    if (a == true)
                    {
                        _logger.Debug("Method reject start working");
                        TimerCallback tm = new TimerCallback(AutoRejection);
                        Timer timer = new Timer(tm, 0, 0, outNumber);

                        _logger.Debug("Method reject finish working");
                        
                        return true;
                    }
                    else
                    {
                        _logger.Debug("Method reject don't finish, because can't convert to int");

                        return false;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Exception in main {ex.Message}");
                    return false;
                }

            }

        }


        public IEnumerable<TaskApi> GetAllTaskForRejection()
        {
            try
            {
                _logger.Debug("Get all task method start");
                var rep = _taskRepository.GetAllTask();
                var map = _mapper.Map<IEnumerable<TaskApi>>(rep);
                _logger.Info("Success method. finith method GetAllTask");
                return map;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception in getalltask {ex.Message}");
                return null;
            }
        }

    }
}