using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Management_System.Studentclass
{
//    Class: Student
//Properties:
//• int StudentId
//• string Name
//• int Age
//• List<Course> Courses
//Methods:
//• bool Enroll(Course course)
//• string PrintDetails()
    internal class Student
    {
        public int  StudentID { get; init; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }
        public Student(string name,int id, int age)
        {
            StudentID = id;
            Name = name;
            Age = age;
            Courses = new List<Course>();
        }
        public bool Enroll(Course course)
        {
            bool Enrolled = Courses.Contains(course);
            if (!Enrolled)
            {
                Courses.Add(course);
                return true;
            }
            return false;
        }
        public int ID_()=> StudentID;

        public void  PrintDetails()
        {
            Console.WriteLine($"The Student Name: {Name}");
            Console.WriteLine($"The Student ID: {StudentID}");
            Console.WriteLine($"The Student Age: {Age}");
            Console.Write("The Enrolled Courses are: ");
            foreach (var course in Courses)
            {
                Console.Write($"{course.Title} ");
            }
            Console.WriteLine("\n------------------------------------------------");
        }
    }
}
