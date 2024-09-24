namespace BackEnd_Students.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string CurrentCourse { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
