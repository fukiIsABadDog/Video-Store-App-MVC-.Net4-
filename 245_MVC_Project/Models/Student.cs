using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _245_MVC_Project.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public double GPA { get; set; }
        public Student()
        {
            
        }
        public static Dictionary<int, Student> Students
        {
            get
            {
                if (studentList == null)
                {
                    studentList = new Dictionary<int, Student>();
                    studentList.Add(101, new Student() { StudentId = 101, FirstName = "James", LastName = "River", GPA = 3.37 });
                    studentList.Add(102, new Student()
                    {
                        StudentId = 102,
                        FirstName = "Hugh",
                        LastName = "Gaknot",
                        GPA = 3.14
                    });
                    studentList.Add(103, new Student()
                    {
                        StudentId = 103,
                        FirstName = "Chip N.",
                        LastName = "Hamm",
                        GPA = 2.84
                    });
                };
                return studentList;
            }
        }
        private static Dictionary<int, Student> studentList { get; set; }
        public List<Roster> Enrollments
        {
            get
            {
                return Roster.Students(StudentId);
            }
        }
        public static Student Get(int studentId)
        {
            return Students.ContainsKey(studentId) ? Students[studentId] : null;
        }
    }
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Number { get; set; }
        public int Credits { get; set; }
        public List<Roster> Enrollments { get
            {
                return Roster.Courses(CourseId);
            }
        }
        public static Dictionary<int, Course> Courses
        {
            get
            {
                if (courses == null)
                {
                    courses = new Dictionary<int, Course>();
                    Courses.Add(201, new Course()
                    {
                        CourseId = 201,
                        Name = "C#-1",
                        Department = "ITP",
                        Number = "136",
                        Credits = 4
                    });
                    Courses.Add(202, new Course()
                    {
                        CourseId = 202,
                        Name = "C#-1",
                        Department = "ITP",
                        Number = "236",
                        Credits = 4
                    });
                    Courses.Add(203, new Course()
                    {
                        CourseId = 203,
                        Name = "User Interface",
                        Department = "ITP",
                        Number = "245",
                        Credits = 4
                    });
                    Courses.Add(204, new Course()
                    {
                        CourseId = 204,
                        Name = "American History",
                        Department = "HIS",
                        Number = "101",
                        Credits = 3
                    });
                };
                return courses;
            }
        }
        private static Dictionary<int, Course> courses { get; set; }
        public static Course Get(int courseId)
        {
            return Courses.ContainsKey(courseId) ? Courses[courseId] : null;
        }
        public Course()
        { }
    }
    public class Roster
    {
        public int RosterId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Nullable<char> Grade { get; set; }
        public Nullable<int> GradePoints { get; set; }

        public static Dictionary<int, Roster> Enrollments
        {
            get
            {
                if (enrollments == null)
                {
                    enrollments = new Dictionary<int, Roster>();
                    enrollments.Add(301, new Roster()
                    {
                        RosterId = 301,
                        StudentId = 101,
                        CourseId = 201,
                        Grade = 'A'
                    });
                    enrollments.Add(302, new Roster()
                    {
                        RosterId = 302,
                        StudentId = 101,
                        CourseId = 202,
                        Grade = 'B'
                    });
                    enrollments.Add(303, new Roster()
                    {
                        RosterId = 303,
                        StudentId = 101,
                        CourseId = 203,
                        Grade = 'C'
                    });
                    enrollments.Add(304, new Roster()
                    {
                        RosterId = 304,
                        StudentId = 103,
                        CourseId = 203,
                        Grade = 'A'
                    });
                    enrollments.Add(305, new Roster()
                    {
                        RosterId = 305,
                        StudentId = 103,
                        CourseId = 204,
                        Grade = 'C'
                    });

                }
                return enrollments;
            }
        }
        private static Dictionary<int, Roster> enrollments { get; set; }
        public static List<Roster> Students(int studentId)
        {
            var students = new List<Roster>();
            foreach (var roster in Enrollments.Values)
            {
                if (roster.StudentId == studentId)
                    students.Add(roster);
            }
            return students;
        }

        public static List<Roster> Courses(int courseId)
        {
            var students = new List<Roster>();
            foreach (var roster in Enrollments.Values)
            {
                if (roster.CourseId == courseId)
                    students.Add(roster);
            }
            return students;
        }

        public Roster()
        { }
    }
}