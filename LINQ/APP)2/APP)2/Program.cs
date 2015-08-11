using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Process> processList = from p in Process.GetProcesses()
                                               where String.Equals(p.ProcessName, "svchost")
                                               orderby p.WorkingSet64 descending
                                               select p;

            foreach(Process p in processList)
            {
                Console.WriteLine("{0} {1}",p.ProcessName, p.WorkingSet64);
            }

            Console.Read();
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
