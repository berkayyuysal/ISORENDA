using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Category : IEntity
    {
        public Category()
        {
            CategoryCourses = new HashSet<CategoryCourse>();
            InverseCategoryParent = new HashSet<Category>();
        }

        public Guid CategoryId { get; set; }
        public Guid CategoryParentId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual Category CategoryParent { get; set; }
        public virtual ICollection<CategoryCourse> CategoryCourses { get; set; }
        public virtual ICollection<Category> InverseCategoryParent { get; set; }
    }
}
