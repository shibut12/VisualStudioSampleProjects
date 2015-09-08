using System.ComponentModel;

namespace JSONProject.Models
{
    public class Employee
    {
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName{ get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("Salary")]
        public int salary { get; set; }
    }
}
