using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager(new EfStudentDal());
            string gender = String.Empty;
            foreach (var student in studentManager.GetAllStudents())
            {
                Console.WriteLine("Adı:" + student.StudentName.ToString());
                Console.WriteLine("Soyadı:" + student.StudentSurname.ToString());
                if (student.StudentGender == 0)
                {
                    gender = "Erkek";
                }
                else
                {
                    gender = "Kadın";
                }
                Console.WriteLine("Cinsiyet:" + gender);
                Console.WriteLine("-----------------------------------------------");
            }
            Console.ReadLine();
        }
    }
}
