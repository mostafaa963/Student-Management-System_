using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Management_System.Studentclass
{
    //    Properties:
    //• int InstructorId
    //• string Name
    //• string Specialization
    //Methods:
    //• string PrintDetails()
    internal class Instructor
    {
        public int InstructorID { get; init; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public Instructor(string name = "unknew", int id = 0, string specialization = "special")
        {
            InstructorID = id;
            Name = name;
            Specialization = specialization;
        }
        public void PrintDetails()
        {
            Console.WriteLine($"The Instructor Name: {Name}");
            Console.WriteLine($"The Instructor ID: {InstructorID}");
            Console.WriteLine($"The Instructor Specialization: {Specialization}");
            Console.WriteLine("------------------------------------------------");
        }
    }
}
