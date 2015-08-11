using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Person samplePerson = new Person
                {
                    firstName = "Sabu",
                    lastName = "Balakrishnan",
                    age = 23,
                    gender = "Male"
                };
                using (personContext _dbContext = new personContext())
                {
                    _dbContext.Persons.Add(samplePerson);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Error occured!");
            }
            finally
            {
                Console.WriteLine("Completed execution of program");
            }

        }
    }
}
