using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [FaultContract(typeof(ServiceData))]
        ServiceData DivideNumbers(int number1, int number2);
    }

    [DataContract]
    public class ServiceData
    {
        [DataMember]
        public double result { get; set; }
        [DataMember]
        public int errorNumber { get; set; }
        [DataMember]
        public string errorMessage { get; set; }
    }
}
