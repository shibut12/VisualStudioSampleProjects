using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst001.Models;

namespace CodeFirst001
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User record is going to written into tables.");

            using(var _dbContext = new SchoolContext())
            {
                var _studentRecords = new Student
                {
                    FirstName = "Shibu",
                    LastName="Thannikkunnath",
                    Course = Course.MCSD,
                    Gender = Gender.Male
                };

                var _departmentRecords = new Department
                {
                    DepartmentName = "CSE"
                };

                _dbContext.Students.Add(_studentRecords);
                _dbContext.Departments.Add(_departmentRecords);

                _dbContext.SaveChanges();
            }

            Console.WriteLine("Date written into Database");
            Console.Read();
        }
    }
}
