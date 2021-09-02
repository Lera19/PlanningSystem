using NLog;
using PlanningSystemDAL;
using System;
using System.Linq;

namespace TaskServicePS
{
    public class StatusChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void ChangeOfStatus()
        {
            logger.Info("Change status start");
            try
            {
                using (var context = new TaskContext())
                {
                    logger.Info("Status change when status = todo");
                    var todo = context.Task.Where(i => i.StatusTask == Statuses.ToDo).ToList();
                    foreach (var i in todo)
                    {
                        i.StatusTask = Statuses.Ready;
                        logger.Info("ready change");
                    }
                    logger.Info("Status change when status = ready");
                    var todo1 = context.Task.Where(i => i.StatusTask == Statuses.Ready).ToList();
                    foreach (var i in todo1)
                    {
                        i.StatusTask = Statuses.InProgress;
                        logger.Info("ready change");
                    }
                    logger.Info("Status change when status = inprogress");
                    var todo3 = context.Task.Where(i => i.StatusTask == Statuses.InProgress).ToList();
                    foreach (var i in todo3)
                    {
                        i.StatusTask = Statuses.Completed;
                        logger.Info("ready change");
                    }
                    logger.Info("Status Completed");
                    context.SaveChanges();
                }

                logger.Debug("Change status finish");
            }

            catch (Exception ex)
            {
                logger.Error($"Error change status {ex.Message}");
            }
        }
    }
}

