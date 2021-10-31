using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public bool AddTeacher(Teacher teacher)
        {
            // İş kodları
            _teacherDal.Add(teacher);
            return true;
        }
    }
}
