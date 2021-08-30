using System;
using System.ComponentModel.DataAnnotations;

namespace PlanningSystemDAL.Models
{
    public class Task
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateTimeAddeed { get; set; }
        [Required]
        public Statuses StatusTask { get; set; }
        [Required]
        public Priorities Priority { get; set; }
    }
}
