using NUnit.Framework;
using AutoRejectionTask.Service;

namespace PlanningSystem.NunitTest
{
    [TestFixture]
    public class AutoRejectionTaskTests
    {
        [Test]
        public void TimerForRejection_ReturnedFalse()
        {
            var service = new RejectionService();

            Assert.False(service.TimerForRejection("fhgjd"));

        }


        [Test]
        public void TimerForRejection_ReturnedTrue()
        {
            var service = new RejectionService();

            Assert.True(service.TimerForRejection("100000"));

        }

        [Test]
        public void GetAllTaskForRejection_IsNotEmpty()
        {
            var service = new RejectionService().GetAllTaskForRejection();

            CollectionAssert.IsNotEmpty(service);
        }

        [Test]
        public void GetAllTaskForRejection_NotNull()
        {
            var service = new RejectionService().GetAllTaskForRejection();

            Assert.NotNull(service);
        }
    }
}
