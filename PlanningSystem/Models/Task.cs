using System;
using System.ComponentModel.DataAnnotations;

namespace PlanningSystemDAL.Models
{
    public class Task
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeAddeed { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public StatusesForTask StatusTask { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        public Priorities Priority { get; set; }
        [Required]
        public StatusesForRejection StatusesForRejection { get; set; }
    }
}