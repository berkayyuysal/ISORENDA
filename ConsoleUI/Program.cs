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
            StudentTest();
            //TeacherTest();
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
            if (t.AddTeacher(teacher))
            {
                Console.WriteLine("eklendiii whoo");
            }
            Console.ReadLine();
        }

        private static void StudentTest()
        {
            StudentManager studentManager = new StudentManager(new EfStudentDal());
            string gender = String.Empty;
            foreach (var student in studentManager.GetStudentDetails())
            {
                if (student.Gender == 0)
                {
                    gender = "Erkek";
                }
                else
                {
                    gender = "Kadın";
                }
                Console.WriteLine("Öğrenci Adı:" + student.StudentName + " " +"Öğretmen Adı:" + student.TeacherName + " " + "Öğretmen ve öğrenci cinsiyeti:" + " " + gender + " " + student.Gender);
                //Console.WriteLine("Soyadı:" + student.StudentSurname.ToString());
                //Console.WriteLine("Cinsiyet:" + gender);
                Console.WriteLine("-----------------------------------------------");
            }
            Console.ReadLine();
        }
    }
}
