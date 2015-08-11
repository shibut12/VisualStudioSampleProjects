using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public ServiceData DivideNumbers(int number1, int number2)
        {
            double result=0;
            ServiceData serviceData= new ServiceData();
            try
            {
                serviceData.result = number1/number2;
                return serviceData;
            }
            catch (DivideByZeroException ex)
            {
                serviceData.errorNumber = 1;
                serviceData.errorMessage = "Error occured in service";
                throw new FaultException<ServiceData>(serviceData,ex.ToString());
            }

            //return result;
        }
    }
}
