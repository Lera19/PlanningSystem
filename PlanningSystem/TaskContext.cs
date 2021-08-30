using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using PlanningSystemDAL.Models;

namespace PlanningSystem
{
    public class TaskContext : DbContext
    {
        public TaskContext(): base("DefaultConnection")
        {
            Database.SetInitializer(new Initializer());
        }
        public DbSet<Task> Task { get; set; }

    }
}
