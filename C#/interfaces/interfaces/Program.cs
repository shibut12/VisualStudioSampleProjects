using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    interface ICustomer
    {
        void print();
    }

    class customer : ICustomer
    {
        public void print()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            customer c1 = new customer();
            c1.print();
        }
    }
}
