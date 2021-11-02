using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class StudentDetailDto: IDto
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
        public int Gender { get; set; }
    }
}
