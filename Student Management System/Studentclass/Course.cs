using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization.Metadata;

namespace Student_Management_System.Studentclass
{
//            Properties:
//• int CourseId
//• string Title
//• Instructor Instructor
//Methods:
//• string PrintDetails()
    internal class Course
    {
        public int  CourseID { get; init; }
        public string Title { get; set; }
        Instructor Instructor { get; set; }
        public Course(string title ,int id,Instructor ins)
        {
            CourseID = id;
            Title = title;
            // if ins is null create new Instructor else assign ins to Instructor
            Instructor = ins ?? new Instructor();
        }
        public void PrintDetails()
        {
            Console.WriteLine($"The Course Title: {Title}");
            Console.WriteLine($"The Course ID: {CourseID}");
            Console.WriteLine($"The Course Instructor: {Instructor.Name}");
            Console.WriteLine("------------------------------------------------");
        }
        public string GetInstructorName() => Instructor.Name;
    }
}
