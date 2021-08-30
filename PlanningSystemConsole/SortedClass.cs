using PlanningSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanningSystemConsole
{
    public class SortedClass
    {
        private List<Task> _task = new List<Task>();
        public void SortedByID() 
        {
          //  List<Tasks> task = new List<Tasks>();

            var sortedTasksID = from u in _task
                                orderby u.ID
                                select u;

            foreach (Task u in sortedTasksID)
            {
                Console.WriteLine(u.ID);
            }
        }
        public void SortedByStatus()
        {
            //List<Tasks> task = new List<Tasks>();

            var sortedTasksStatus = from u in _task
                                orderby u.StatusTask
                                select u;

            foreach (Task u in sortedTasksStatus)
            {
                Console.WriteLine(u.StatusTask);
            }
        }
        public void SortedByPriority()
        {
            //List<Tasks> task = new List<Tasks>();

            var sortedTasksPriority = from u in _task
                                orderby u.Priority
                                select u;

            foreach (Task u in sortedTasksPriority)
            {
                Console.WriteLine(u.Priority);
                
            }
        }
        public void SortedbyDateTime()
        {
            //List<Tasks> task = new List<Tasks>();

            var sortedTasksDate = from u in _task
                                orderby u.DateTimeAddeed
                                select u;

            foreach (Task u in sortedTasksDate)
            {
                Console.WriteLine(u.DateTimeAddeed);
            }
        }

        //public void OutputListTasks(List<Tasks> sorted)
        //{
        //    Console.WriteLine(sorted.ID.ToString(),
        //        sorted.Name, sorted.,
        //        sorted.StatusTask, sorted.Description);
        //}
    }
}
