using System;
using System.ServiceModel;

namespace AutoRejectionTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var serviceHost = new ServiceHost(typeof(AutoRejectionTask.Service.RejectionService));
                serviceHost.Open();

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();


                serviceHost.Close();
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine(timeProblem.Message);
                Console.Read();
            }
            catch (FaultException faultEx)
            {
                Console.WriteLine(
                  faultEx.Message,
                  faultEx.StackTrace);
                Console.Read();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine(commProblem.Message);
                Console.Read();
            }


        }
    }

}