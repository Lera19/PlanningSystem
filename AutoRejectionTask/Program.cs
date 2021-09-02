using NLog;
using PlanningSystemDAL;
using System;
using System.Linq;
using System.Threading;

namespace AutoRejectionTask
{
    public class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            Console.WriteLine("AutoRejection");
            while (true)
            {
                logger.Debug("Method reject open");
                try
                {
                    logger.Debug("Method reject start working");
                    TimerCallback tm = new TimerCallback(DeleteTaskByStatus);
                    Timer timer = new Timer(tm, 0, 0, 100000);
                    Console.ReadLine();

                    logger.Debug("Method reject finish working");
                }
                catch (Exception ex)
                {
                    logger.Error($"Exception in main {ex.Message}");
                }

            }
        }

        public static void DeleteTaskByStatus(object obj)
        {
            logger.Debug("Delete task method started");
            logger.Info("Delete task method started");
            DateTime dateTimeSettings = DateTime.Now.ToUniversalTime().AddMinutes(-3);

            using (var context = new TaskContext())
            {

                var date = context.Task.Any(i => i.DateTimeAddeed < dateTimeSettings);
                var rej = context.Task.Any(i => i.StatusTask == Statuses.ToDo);
                    if (rej == true && date==true)
                    {
                        var deleteTask = context.Task.Where(c => c.StatusTask == Statuses.ToDo);
                        context.Task.RemoveRange(deleteTask);
                        context.SaveChanges();
                        logger.Info("Delete success done");
                    }
                    else
                    {

                        logger.Error($"Exception Not found task\n");
                    }
            }
        }

    }
}