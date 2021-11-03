using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Course: IEntity
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
