using Microsoft.Extensions.DependencyModel;

namespace Student_Console_App;
using Microsoft.EntityFrameworkCore;
using Student_Class_Library;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        CollegeContext CollegeContext = new CollegeContext();
       
        {
           

            var student = new Student
            {
                Name = "John Doe",
                Age = 22,
                EmailAddress = "john.doe@example.com",
                Courses = new System.Collections.Generic.List<Course>
                {
                    new Course { Name = "Math 2", Department = "Mathematics", Lecturer = "Mr. Smith" },
                    new Course { Name = "History 3", Department = "History", Lecturer = "Mrs. Johnson" }
                }
            };

            CollegeContext.Students.Add(student);

            CollegeContext.SaveChanges();


            var addedStudent = CollegeContext.Students
                                      .Include(s => s.Courses)
                                      .FirstOrDefault(s => s.Name == "John Doe");

            if (addedStudent != null)
            {
                Console.WriteLine($"Student: {addedStudent.Name}, Email: {addedStudent.EmailAddress}, Age: {addedStudent.Age}");
                foreach (var course in addedStudent.Courses)
                {
                    Console.WriteLine($"Enrolled in Course: {course.Name} - {course.Department}, Lecturer: {course.Lecturer}");
                }
            }
        }
    }
}

