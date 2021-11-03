using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseTest();
            //StudentTest();
            //TeacherTest();
        }

        private static void CourseTest()
        {
            CourseManager c = new CourseManager(new EfCourseDal());
            Course course = new Course
            {
                CourseId = new Guid(),
                CourseName = "Hafıza Teknikleri"
            };
            var a = c.AddCourse(course);

            if (a.IsSuccess)
            {
                Console.WriteLine("owww yeaa");
            }
            else
            {
                Console.WriteLine("fuckkk");
            }
        }

        private static void TeacherTest()
        {
            TeacherManager t = new TeacherManager(new EfTeacherDal());
            Teacher teacher = new Teacher
            {
                TeacherId = new Guid(),
                TeacherName = "DenemeAd1",
                TeacherSurname = "DenemeSoyad1",
                TeacherGender = 0
            };
            if (t.AddTeacher(teacher).IsSuccess)
            {
                Console.WriteLine("eklendiii whoo");
            }
            Console.ReadLine();
        }

        private static void StudentTest()
        {
            StudentManager studentManager = new StudentManager(new EfStudentDal());
            var result = studentManager.GetAllStudents();
            string gender = String.Empty;
            if (result.IsSuccess)
            {
                foreach (var student in result.Data)
                {
                    Console.WriteLine(student.StudentName);
                    Console.WriteLine("-----------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            Console.ReadLine();
        }
    }
}
