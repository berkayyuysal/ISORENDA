using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Student:IEntity
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentGender { get; set; }
        public Guid CourseId { get; set; }
    }
}
