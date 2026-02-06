using Student_Management_System.Studentclass;
using Student_Management_System.Studentmanagement;
using System.Net.Quic;
using System.Net.WebSockets;

namespace Student_Management_System
{
    internal class Program
    {
        //        Sample Console Menu(on the StudentManager) :
        //1. Add Student(hint: start with empty list of courses)
        //2. Add Instructor
        //3. Add Course(hint: select the instructor by id)
        //4. Enroll Student in Course
        //5. Show All Students
        //6. Show All Courses
        //7. Show All Instructors
        //8. Find the student by id or name
        //9. Fine the course by id or name
        //10. Exit
        //Bonus:
        //11. Check if the student enrolled in specific course
        //12 Return the instructor name by course name
        static void Main(string[] args)
        {
            StudentManagement School = new StudentManagement();
            while (true)
            {
                //bool Quit = false;
                Console.WriteLine($"1- Add Student");
                Console.WriteLine($"2- Add Instructor");
                Console.WriteLine($"3- Add Course");
                Console.WriteLine($"4- Enroll Student in Course");
                Console.WriteLine($"5- Show All Students");
                Console.WriteLine($"6- Show All Courses");
                Console.WriteLine($"7- Show All Instructors");
                Console.WriteLine($"8- Find the student by id or name");
                Console.WriteLine($"9- Fine the course by id or name");
                Console.WriteLine($"10- Check if the student enrolled in specific course");
                Console.WriteLine($"11- Return the instructor name by course name");
                Console.WriteLine($"12- Exit");
                byte  choice = Convert.ToByte( Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the Student Name: ");
                        string name = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter the Student ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Student Age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Student student = new Student(name, id, age);
                        School.AddStudent(student);
                        break;
                    case 2:
                        Console.Write("Enter the Instructor Name: ");
                        string instName = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter the Instructor ID: ");
                        int insId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Instructor specialization: ");
                        string insSpecialization = Console.ReadLine() ?? string.Empty;
                        School.AddInstructor(new Instructor(instName, insId, insSpecialization));
                        break;
                    case 3:
                        Console.Write("Enter the Course Titel: ");
                        string tiName = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter the Course Id: ");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Instructor Id: ");
                        int  instructorId =Convert.ToInt32( Console.ReadLine());
                        var findinstructor = School.FindInstructor(instructorId);
                        if (findinstructor != null)
                        {
                            School.AddCourse(new Course(tiName, courseId, findinstructor));
                        }
                        else
                        {
                            Console.WriteLine("Instructor not found");
                        }
                        break;
                    case 4:
                        Console.Write("Enter the Student Id: ");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Course Id: ");
                        int course_Id = Convert.ToInt32(Console.ReadLine());
                        School.EnrollStudentInCourse(studentId, course_Id);
                        break;
                    case 5:
                        School.ShowAllStudents();
                        break;
                    case 6:
                        School.ShowAllCourses();
                        break;
                    case 7:
                        School.ShowAllInstructors();
                        break;
                    case 8:
                        {
                            Console.Write("choice if search by name[1] or by id[0]: ");
                            char searchChoice_ = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            if (searchChoice_ == '1')
                            {
                                Console.Write("Enter the Student Name: ");
                                string studentName = Console.ReadLine()?? string.Empty;
                                var findStudent = School.FindStudent(studentName);
                                if (findStudent != null)
                                {
                                    Console.WriteLine("-------------------------------- ");
                                    findStudent.PrintDetails();
                                }
                                else
                                {
                                    Console.WriteLine("Student not found");
                                }
                            }
                            else
                            {
                                Console.Write("Enter the Student Id: ");
                                int student_Id = Convert.ToInt32(Console.ReadLine());
                                var findStudent = School.FindStudent(student_Id);
                                if (findStudent != null)
                                {
                                    Console.WriteLine("-------------------------------- ");
                                    findStudent.PrintDetails();
                                }
                                else
                                {
                                    Console.WriteLine("Student not found");
                                }
                            }
                        }
                        break;
                    case 9:
                        {
                            Console.Write("choice if search by name[1] or by id[0]: ");
                            char searchCourseChoice = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            if (searchCourseChoice == '1')
                            {
                                Console.Write("Enter the Course Name: ");
                                string courseName = Console.ReadLine()?? string.Empty;
                                var findCourse = School.FindCourse(courseName);
                                if (findCourse != null)
                                {
                                    Console.WriteLine("--------------------------------");
                                    findCourse.PrintDetails();
                                }
                                else
                                {
                                    Console.WriteLine("Course not found");
                                }
                            }
                            else
                            {
                                Console.Write("Enter the Course Id: ");
                                int course_Id_ = Convert.ToInt32(Console.ReadLine());
                                var findCourse = School.FindCourse(course_Id_);
                                if (findCourse != null)
                                {
                                    Console.WriteLine("-------------------------------- ");
                                    findCourse.PrintDetails();
                                }
                                else
                                {
                                    Console.WriteLine("Course not found");
                                }
                            }
                        }
                        break;
                    case 10:
                        Console.Write("Enter the Student name: ");
                        string studentName_ = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter the Course Title: ");
                        string courseTitle_ = Console.ReadLine() ?? string.Empty;
                        var checkStudent = School.FindStudent(studentName_);
                        if (checkStudent != null)
                        {
                            bool checkCourse = checkStudent.Courses.Exists(c => c.Title == courseTitle_);
                            if (checkCourse)
                                Console.WriteLine($"the {checkStudent.Name} is Enrolled in {courseTitle_}");
                            else
                                Console.WriteLine($"the {checkStudent.Name} is not in {courseTitle_}");
                        }
                        else
                            Console.WriteLine($"the {studentName_} is not in school...");
                        break;
                    case 11:
                        Console.Write("Enter the Course Title: ");
                        string courseTitle = Console.ReadLine() ?? string.Empty;
                        var course_= School.FindCourse(courseTitle);
                        if (course_ != null)
                        {
                            Console.WriteLine($"the Instructor of {courseTitle} is {course_.GetInstructorName()}");

                        }
                        else
                        {
                            Console.WriteLine("sorry this course is not in School....");
                        }
                         break;
                    case 12:
                        //Quit = true;
                        return;
                        //break;
                        default:
                        Console.WriteLine("Invalid number, try again.");
                        break;
                }
                //if (Quit)
                //{
                //    break;
                //}
            }
        }
    }
}
