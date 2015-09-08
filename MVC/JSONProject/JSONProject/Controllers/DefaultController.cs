using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using JSONProject.Models;

namespace JSONProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            Employee employee1 = new Employee
            {
                firstName = "Shibu",
                lastName = "Thannikkunnath",
                gender = "Male",
                salary = 100000
            };

            Employee employee2 = new Employee
            {
                firstName = "Todd",
                lastName = "Grover",
                gender = "Male",
                salary = 50000
            };

            List<Employee> employees =new List<Employee>();
            employees.Add(employee1);
            employees.Add(employee2);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string JSONstring = serializer.Serialize(employees);

            ViewBag.jsonString = JSONstring;
            return View();
        }

        public ActionResult jstonet()
        {
            string jsonString = "[{ \"firstName\":\"Shibu\",\"lastName\":\"Thannikkunnath\",\"gender\":\"Male\",\"salary\":100000},{ \"firstName\":\"Todd\",\"lastName\":\"Grover\",\"gender\":\"Male\",\"salary\":50000}]";

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Employee> employees = (List<Employee>)serializer.Deserialize(jsonString, typeof (List<Employee>));

            ViewBag.employees = employees;
            return View();
        }

        public ActionResult editEmployee()
        {
            return View();
        }
    }
}