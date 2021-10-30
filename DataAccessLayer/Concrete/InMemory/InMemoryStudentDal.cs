using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Concrete.InMemory
{
    public class InMemoryStudentDal : IStudentDal
    {
        //List<Student> _students;
        //public InMemoryStudentDal()
        //{
        //    //_students = students;
        //    _students = new List<Student> {
        //        new Student {StudentId = new Guid(), StudentName = "AdDeneme1", StudentSurname = "SoyadDeneme1", StudentGender = 0},
        //        new Student {StudentId = new Guid(), StudentName = "AdDeneme2", StudentSurname = "SoyadDeneme2", StudentGender = 1}
        //    };
        //}

        //public bool Add(Student entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(Student entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Student> GetAll(Expression<Func<Student, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public Student GetOne(Expression<Func<Student, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Update(Student entity)
        //{
        //    throw new NotImplementedException();
        //}
        public void Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll(Expression<Func<Student, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Student GetOne(Expression<Func<Student, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
