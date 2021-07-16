using System.Collections.Generic;

namespace PlanningSystem.Models
{
    public class StatusForPlanning
    {
        public StatusForPlanning() { }
        public int ID { get; set; }
        public EnumForStatus Status { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}
