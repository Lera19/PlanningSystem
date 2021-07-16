using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningSystem.Models
{
    public class PriorityForTasks
    {
        public int ID { get; set; }
        public EnumForPriority EnumForPriority {get; set;}
        public ICollection<Tasks> Tasks { get; set; }
    }
}
