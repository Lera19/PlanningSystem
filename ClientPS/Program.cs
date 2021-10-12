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