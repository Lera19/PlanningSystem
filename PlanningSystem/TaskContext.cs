using System.Data.Entity;
using PlanningSystemDAL.Models;

namespace PlanningSystemDAL
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new Initializer());
        }
        public DbSet<Task> Task { get; set; }
    }
}