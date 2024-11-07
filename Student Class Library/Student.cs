namespace Student_Class_Library
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set;}
        public ICollection<Course> Courses { get; set; }
    }
}
