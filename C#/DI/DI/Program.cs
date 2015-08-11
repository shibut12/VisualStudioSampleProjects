using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            NeedDependancyClass a = new NeedDependancyClass();
        }
    }

    public class NeedDependancyClass
    {
        private readonly DependancyClass _b;
        public NeedDependancyClass()
        {
            _b = new DependancyClass();
        }

        public void Test()
        {
            _b.Test();
        }
    }

    public class DependancyClass
    {
        public void Test()
        {
            //test method body goes here
        }
    }
}
