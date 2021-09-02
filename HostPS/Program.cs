using System;
using System.ServiceModel;

namespace HostPS
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var serviceHost = new ServiceHost(typeof(TaskServicePS.TaskService));
                serviceHost.Open();

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();

                serviceHost.Close();
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine(timeProblem.Message);
                Console.ReadLine();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine(commProblem.Message);
                Console.ReadLine();
            }
        }
    }
}