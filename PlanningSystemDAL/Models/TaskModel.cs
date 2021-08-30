using System;

namespace PlanningSystemBL.Models
{
    public class TaskModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description(string descr)
        {
            return descr;
        }
        public DateTime DateTimeAddeed { get; set; }
        public StatusesModel StatusTaskModel { get; set; }
        public PrioritiesModel PriorityModel { get; set; }
    }
}
