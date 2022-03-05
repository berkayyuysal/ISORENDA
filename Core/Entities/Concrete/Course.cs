using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Course : IEntity
    {
        public Course()
        {
            CategoryCourses = new HashSet<CategoryCourse>();
            CourseMentors = new HashSet<CourseMentor>();
        }

        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual ICollection<CategoryCourse> CategoryCourses { get; set; }
        public virtual ICollection<CourseMentor> CourseMentors { get; set; }
    }
}
