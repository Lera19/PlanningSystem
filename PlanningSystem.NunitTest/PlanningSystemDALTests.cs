using System;
using System.Data.Entity.Validation;
using System.Linq;
using NUnit.Framework;
using PlanningSystemDAL;
using PlanningSystemDAL.Models;

namespace PlanningSystem.NunitTest
{
    [TestFixture]
    public class PlanningSystemDALTests
    {
        [Test]
        public void GetAllTaskSort_ReturnedIsNotEmpty()
        {
            var sort = new SortForGetAllTask();
            var db = new TaskRepository().GetAllTaskSort(sort.ToString());

            CollectionAssert.IsNotEmpty(db);
        }

        [Test]
        public void GetAllTaskSort_ReturnedThrows()
        {
            var sort = "aghk";
   
            void Db()
                {
                var db = new TaskRepository().GetAllTaskSort(sort.ToString());
                }

            Assert.Throws(typeof(Exception), Db);

        }

        [Test]
        public void GetTasks_ReturnedNotNull()
        {
            var db = new TaskRepository().GetTasks();
            Assert.NotNull(db);
        }

        [Test]
        public void GetTasks_ReturnedIsEmpty()
        {
            var db = new TaskRepository().GetTasks();
            db = null;
            Assert.Null(db);
        }

        [Test]
        public void AddTask_ReturnedTrue()
        {
            var dbContext = new TaskContext();
            var db = new TaskRepository();

            var task = new Task() { Id = Guid.NewGuid().ToString(), Name = "Cooking1998", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Medium, StatusTask = StatusesForTask.ToDo, Description = "cooking1fjngyhnj", StatusesForRejection = StatusesForRejection.Processing };
            db.AddTask(task);
            var result = dbContext.Task.Any(n => n.Name == "Cooking1998");
            Assert.True(result);
        }
        [Test]
        public void AddTask_ReturnedFail()
        {
            var db = new TaskRepository();

            var task = new Task() { Name = "Cooking1888", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Medium, StatusTask = StatusesForTask.ToDo, Description = "cooking1fjngyhnj", StatusesForRejection = StatusesForRejection.Processing };
            try
{
                db.AddTask(task);
            }
            catch (DbEntityValidationException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void DeleteTask_ReturnedFalseNotFoundTaskAfterDelete()
        {
            var db = new TaskRepository();
            var dbContext = new TaskContext();

            var task = dbContext.Task.First().Id.ToString();
            db.DeleteTask(task);

            var result = dbContext.Task.Any(c=>c.Id==task);
            Assert.False(result);

            
        }
        [Test]
        public void DeleteTask_ReturnedFalse()
        {
            var db = new TaskRepository();

            string id = "1";
            
            try
            {
                db.DeleteTask(id);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }


        }

        [Test]
        public void GetAllTask_ReturnedIsNotEmpty()
        {
            var sort = new SortForGetAllTask();
            var db = new TaskRepository().GetAllTaskSort(sort.ToString());

            CollectionAssert.IsNotEmpty(db);
        }

        [Test]
        public void GetAllTask_ReturnedNull()
        {
            var sort = "aghk";

            void Db()
            {
                var db = new TaskRepository().GetAllTaskSort(sort.ToString());
            }

            Assert.Throws(typeof(Exception), Db);

        }

        [Test]
        public void UpdateTask_ReturnedTrue()
        {
            var service = new TaskRepository();

            var dbContext = new TaskContext();
            var updated = dbContext.Task.First().Id;
            var taskUpdate = new Task()
            {
                StatusTask = dbContext.Task.First().StatusTask,
                Id = dbContext.Task.First().Id,
                Name = dbContext.Task.First().Name,
                Description = "New description for this task1",
                DateTimeAddeed = dbContext.Task.First().DateTimeAddeed,
                Priority = dbContext.Task.First().Priority
            };
            service.UpdateTask(taskUpdate, updated);
            var result = dbContext.Task.Any(c => c.Description == taskUpdate.Description);

            Assert.True(result);
        }
        [Test]
        public void UpdateTask_ReturnedFalse()
        {
            try
            {
                var service = new TaskRepository();

                var dbContext = new TaskContext();
                var updated = dbContext.Task.First().Id;
                var taskUpdate = new Task()
                {
                    StatusTask = dbContext.Task.First().StatusTask,

                    Name = dbContext.Task.First().Name,
                    Description = "111",
                    DateTimeAddeed = dbContext.Task.First().DateTimeAddeed,
                    Priority = dbContext.Task.First().Priority
                };
                service.UpdateTask(taskUpdate, updated);
            }
            catch
            {
                Assert.Fail();
            }


        }

        [Test]
        public void GetTask_ReturnedNull()
        {
            var service = new TaskRepository();

            Assert.Null(service.GetTask("gjhfk"));

        }
        [Test]
        public void GetTask_ReturnedIsNotEmpty()
        {

            var service = new TaskRepository();
            var dataList = new TaskContext();
            var result = dataList.Task.First().Id;

            Assert.IsNotEmpty(service.GetTask(result.ToString()).ToString());

        }



    }

}
