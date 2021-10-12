using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using PSContract;

namespace ClientPS
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //ChannelFactory<ITaskService> factory = new ChannelFactory<ITaskService>(new WebHttpBinding(),
            //    new EndpointAddress("http://localhost:44301/TaskService"));
            //factory.Endpoint.Behaviors.Add(new WebHttpBehavior());

            //ITaskService client = factory.CreateChannel();


            //var resultFirst = client.ChangeOfStatusFirstMethod();
            //Console.WriteLine(resultFirst);

            //var resultSecond = client.ChangeOfStatusSecondMethod();
            //Console.WriteLine(resultSecond);
        


            ChannelFactory<IRejectionService> factory = new ChannelFactory<IRejectionService>(new WebHttpBinding(),
               new EndpointAddress("http://localhost:52000/RejectionService"));
            factory.Endpoint.Behaviors.Add(new WebHttpBehavior());

            IRejectionService client = factory.CreateChannel();


            var resultFirst = client.TimerForRejection("100000");
            Console.WriteLine(resultFirst);





            Console.ReadKey();

        }
    }
}