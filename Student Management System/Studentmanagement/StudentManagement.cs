using Student_Management_System.Studentclass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Management_System.Studentmanagement
{
    //    Class: StudentManager(School)
    //Properties:
    //• List<Student> Students
    //• List<Course> Courses
    //• List<Instructor> Instructors
    //Methods:
    //• bool AddStudent(Student student)
    //• bool AddCourse(Course course)
    //• bool AddInstructor(Instructor instructor)
    //• Student FindStudent(int studentId)
    //• Course FindCourse(int courseId)
    //• Instructor FindInstructor(int instructorId)
    //• bool EnrollStudentInCourse(int studentId, int courseId)
    internal class StudentManagement
    {
        List<Student> students = new List<Student>();
        List<Course> Courses = new List<Course>();
        List<Instructor> Instructors = new List<Instructor>();
        public bool AddStudent(Student student)
        {
            bool exists = students.Exists(studentExists => studentExists.StudentID == student.StudentID);
            if (!exists)
            {
                students.Add(student);
                Console.WriteLine($"{student.Name} is Added successfully");
                return true;
            }
            Console.WriteLine($"{student.Name} is Already Exists in the School..");
            return false;
        }
        public bool AddCourse(Course course)
        {
            var exists = Courses.Any(c => c.CourseID == course.CourseID);
            if (!exists)
            {
                Courses.Add(course);
                Console.WriteLine($"{course.Title} is Added successfully");
                return true;
            }
            Console.WriteLine($"{course.Title} is Already Exists in the School..");
            return false;
        }
        public bool AddInstructor(Instructor instructor)
        {
            var exists = Instructors.Any(i => i.InstructorID == instructor.InstructorID);
            if (!exists)
            {
                Instructors.Add(instructor);
                Console.WriteLine($"{instructor.Name} is Added successfully");
                return true;
            }
            Console.WriteLine($"{instructor.Name} is Already Exists in the School..");
            return false;
        }
        public Student? FindStudent(int studentId)
        {
            var findStudent = students.Find(s => s.StudentID == studentId);
            if (findStudent != null)
            {
                //Console.WriteLine($"I found the Student {findStudent.Name}");
                return findStudent;
            }
            //Console.WriteLine($"this Student is Not in the school..");
            return null;
        }
        //over load method for FindStudent
        public Student? FindStudent(string studentname)
        {
            var findStudent = students.Find(s => s.Name == studentname);
            if (findStudent != null)
            {
                //Console.WriteLine($"I found the Student {findStudent.Name}");
                return findStudent;
            }
            //Console.WriteLine($"this Student is Not in the school..");
            return null;
        }
        //over load method for FindCourse
        public Course? FindCourse(int courseId)
        {
            var findCourse = Courses.Find(c => c.CourseID == courseId);
            if (findCourse != null)
            {
                //  Console.WriteLine($"I found the Course {findCourse.Title}");
                return findCourse;
            }
            //Console.WriteLine($"this Course is Not in the school..");
            return null;
        }
        public Course? FindCourse(string coursename)
        {
            var findCourse = Courses.Find(c => c.Title == coursename);
            if (findCourse != null)
            {
                //  Console.WriteLine($"I found the Course {findCourse.Title}");
                return findCourse;
            }
            //Console.WriteLine($"this Course is Not in the school..");
            return null;
        }
        public Instructor? FindInstructor(int instructorId)
        {
            var findInstructor = Instructors.FirstOrDefault(i => i.InstructorID == instructorId);
            if (findInstructor != null)
            {
                // Console.WriteLine($"I found the Instructor {findInstructor.Name}");
                return findInstructor;
            }
            //Console.WriteLine($"this Instructor is Not in the school..");
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            var student = FindStudent(studentId);
            var course = FindCourse(courseId);
            if (student != null && course != null)
            {
                if (student.Courses.Contains(course))
                {
                    Console.WriteLine($"the {student.Name} is Already Enrolled in {course.Title}");
                    return false;
                }
                student.Courses.Add(course);
                Console.WriteLine($"the {student.Name} Enrolled in {course.Title}");
                return true;
            }
            else if (student == null)
            {
                Console.WriteLine($"The Student {studentId} is Not in the School");
                return false;
            }
            else if (course == null)
            {
                Console.WriteLine("Sorry We Don't Have This Course In Our School..");
                return false;
            }
            return false;
        }
        public void ShowAllStudents()
        {
            foreach (var student in students)
            {
                student.PrintDetails();
            }
        }
        public void ShowAllCourses()
        {
            foreach (var course in Courses)
            {
                course.PrintDetails();
            }
        }
        public void ShowAllInstructors()
        {
            foreach (var instructor in Instructors)
            {
                instructor.PrintDetails();
            }
        }
    }
}
