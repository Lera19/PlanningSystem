using NLog;
using PlanningSystem.Interface;
using System;
using System.Linq;
using System.Threading;
using TaskServicePS;

namespace AutoRejection
{
    public class Rejection
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly ITaskRepository _taskRepository;

        //private DateTime dateTimeSettings = DateTime.Now.ToUniversalTime().AddMinutes(3);

        private TaskService service = new TaskService();

        public Rejection(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void RejectionTask()
        {
            //string connectionString = "Server=WS210\\SQLEXPRESS;Database=PS;Trusted_Connection=True;";
            //MySqlConnection con = new MySqlConnection(connectionString);
            
            while (true)
            {
                logger.Debug("Method reject open");
                try
                {
                    logger.Debug("Method reject start working");

                    //var dateTime = tasks.First(i=>i.DateTimeAddeed >= dateTimeSettings);
                    
                    //if(dateTime!=null)
                    //{
                    //    await Task.Run(()=>service.DeleteTask(dateTime.Id));
                    //}
                    //else
                    //{
                    //    TimerCallBack 
                    //}
                    TimerCallback tm = new TimerCallback(DeleteTask);
                    Timer timer = new Timer(tm, 0, 0, 20000);
                    Console.ReadLine();
                    
                    logger.Debug("Method reject finish working");
                }
                catch (Exception ex)
                {
                    logger.Error($"Exception {ex.Message}");
                }
                
            }
        }

        public void DeleteTask(object obj)
        {
            var date = service.GetAllTask();
            try
            {
                logger.Debug("Delete task method");
                _taskRepository.DeleteTask(date.First().Id);
                logger.Info("Delete success");
            }
            catch (Exception ex)
            {
                logger.Error($"Exception {ex.Message}");
            }

        }
    }
}
