using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP02
{
    class Program
    {
        static void Main(string[] args)
        {
            // QueryEmployees();
            QueryTypes();
            //
            Console.Read();
        }

        private static void QueryTypes()
        {
            IEnumerable<string> publicTyoes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                              where t.IsPublic
                                              select t.Name;
            foreach(string name in publicTyoes)
            {
                Console.Write(name);
            }
        }

        private static void QueryEmployees()
        {
            IEnumerable<Employee> employees = new List<Employee>()
            {
                new Employee {ID=1, Name = "Shibu", HireDate=new DateTime(2002,3,5) },
                new Employee {ID=2, Name = "Sabu", HireDate=new DateTime(2012,3,5) },
                new Employee {ID=3, Name = "Tommy", HireDate=new DateTime(2012,6,5) }
            };

            IEnumerable<Employee> sortedEmployees = from e in employees
                                                    where e.HireDate.Year > 2010
                                                    orderby e.Name descending
                                                    select e;

            foreach(Employee sortedEmployee in sortedEmployees)
            {
                Console.WriteLine(sortedEmployee.Name);
            }
        }
    }
}
