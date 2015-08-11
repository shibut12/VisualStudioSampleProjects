using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP01
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] instructors = { "Aron", "Fritz", "Scott", "Keith" };
            //List<string> query = (from s in instructors
            //                      where s.Length == 5
            //                      orderby s descending
            //                      select s).ToList();

            //foreach (string name in query)
            //{
            //    Console.WriteLine(name);
            //}

            IEnumerable<Employee> employees = new List<Employee>
            {
                new Employee {ID=1, Name="Scott", HireDate = new DateTime(2002,3,5) },
                new Employee {ID=2, Name="Shibu", HireDate = new DateTime(2005,4,5) },
                new Employee {ID=3, Name="Poonam", HireDate = new DateTime(2010,6,5) },
                new Employee {ID=2, Name="Max", HireDate = new DateTime(2004,4,5) },
                new Employee {ID=2, Name="Pane", HireDate = new DateTime(2003,4,5) }
            };

            IEnumerable<Employee> query = from e in employees
                                          where e.HireDate.Year < 2005
                                          orderby e.Name
                                          select e;

            foreach(Employee emp in query)
            {
                Console.WriteLine(emp.Name);
            }

            Console.Read();
        }
    }
}
