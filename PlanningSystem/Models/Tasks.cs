using System;
using System.Collections.Generic;
namespace PlanningSystem.Models
{
    public class Tasks
    {
        public Tasks() { }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeAddeed { get; set; }
        public ICollection<StatusForPlanning> StatusTask { get; set; }
        public ICollection<PriorityForTasks> Priority { get; set; }
    }
}
