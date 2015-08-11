namespace CodeFirst001.Models
{
    public class Student
    {
        public Student() { }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Course Course { get; set; }

        public Department Department { get; set; }
    }
}
