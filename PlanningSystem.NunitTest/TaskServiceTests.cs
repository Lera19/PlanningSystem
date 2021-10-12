using Moq;
using NUnit.Framework;
using PlanningSystemDAL;
using PSContract;
using System;
using System.Linq;

namespace PlanningSystem.NunitTest
{
    
    [TestFixture]
    public class TaskServiceTests
    { 
        [Test]
        public void GetAllTaskForStatus_IsNotEmpty()
        {
            var service = new TaskServicePS.TaskService().GetAllTask(SortForGetAllTask.Status.ToString());

            CollectionAssert.IsNotEmpty(service);
        }

        [Test]
        public void GetAllTaskForStatus_ReturnedNull()
        {
            var service = new TaskServicePS.TaskService().GetAllTask("sort");
            Assert.Null(service);
        }

        [Test]
        public void GetAllTaskForDateTime_IsNotEmpty()
        {

            var service = new TaskServicePS.TaskService().GetAllTask(SortForGetAllTask.DateTime.ToString());

            CollectionAssert.IsNotEmpty(service);
        }

        [Test]
        public void GetAllTaskForId_IsNotEmpty()
        {

            var service = new TaskServicePS.TaskService().GetAllTask(SortForGetAllTask.Id.ToString());

            CollectionAssert.IsNotEmpty(service);
        }

        [Test]
        public void GetAllTaskForPriority_IsNotEmpty()
        {

            var service = new TaskServicePS.TaskService().GetAllTask(SortForGetAllTask.Priority.ToString());

            CollectionAssert.IsNotEmpty(service);
        }
        [Test]
        public void GetTaskById_ReturnedIsNotEmpty()
        {
            
            var service = new TaskServicePS.TaskService();
            var dataList = new TaskContext();
            var result =dataList.Task.First().Id;

            Assert.IsNotEmpty(service.GetTask(result.ToString()).ToString());
        }

        [Test]
        public void GetTaskById_ReturnedNull()
        {

            var service = new TaskServicePS.TaskService();

            Assert.Null(service.GetTask("1"));
        }


        [Test]
        public void DeleteTask_ReturnedTrue()
        {
            var service = new TaskServicePS.TaskService();
            var dbContext = new TaskContext();

            Assert.True(service.DeleteTask(dbContext.Task.First().Id.ToString()));

        }

        [Test]
        public void CreateTask_ReturnedTrue()
        {
            var service = new TaskServicePS.TaskService();

            var task = new TaskApi() { Id = Guid.NewGuid().ToString(), Name = "Cooking1", DateTimeAddeed = DateTime.Now.ToUniversalTime(), Priority = Priorities.Medium, StatusTask = StatusesForTask.ToDo, Description = "cooking1fjngyhnj", StatusesForRejection = StatusesForRejection.Processing };            
            var result = service.CreateTask(task);
            
            Assert.True(result);

        }

        [Test]
        public void UpdateTask_ReturnedTrue()
        {
            var service = new TaskServicePS.TaskService();

            var dbContext = new TaskContext();
            var updated = dbContext.Task.First().Id;
            var taskUpdate = new TaskApi()
            {
                StatusTask = dbContext.Task.First().StatusTask,
                Id = dbContext.Task.First().Id,
                Name = dbContext.Task.First().Name,
                Description = "New description for this task",
                DateTimeAddeed = dbContext.Task.First().DateTimeAddeed,
                Priority = dbContext.Task.First().Priority
            };

            Assert.True(service.UpdateTask(updated, taskUpdate));
        }

        [Test]
        public void ChangeOfStatusFirstMethod_ReturnedTrue()
        {
            var service = new TaskServicePS.TaskService().ChangeOfStatusFirstMethod();

            Assert.True(service);

        }
        [Test]
        public void ChangeOfStatusSecondMethod_ReturnedTrue()
        {
            var service = new TaskServicePS.TaskService().ChangeOfStatusSecondMethod();

            Assert.True(service);

        }
    }
}
