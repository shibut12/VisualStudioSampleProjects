using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CalculatorClient.ServiceReference1;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            ServiceData responseData = new ServiceData();

            try
            {
                responseData= client.DivideNumbers(10, 0);
                Console.WriteLine("Result is {0}", responseData.result.ToString());
            }
            catch (FaultException<ServiceData> Fex)
            {
                Console.WriteLine("Error Number is  {0}",Fex.Detail.errorNumber);
                Console.WriteLine("Error Message is {0}",Fex.Detail.errorMessage);
            }

            Console.ReadKey();
        }
    }
}
