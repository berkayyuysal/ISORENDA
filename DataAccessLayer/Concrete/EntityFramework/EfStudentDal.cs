using DataAccessLayer.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfStudentDal : IStudentDal
    {
        public void Add(Student entity)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Student entity)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var deletedEntity = context.Remove(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Student> GetAll(Expression<Func<Student, bool>> filter = null)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                return filter == null
                    ? context.Set<Student>().ToList()
                    : context.Set<Student>().Where(filter).ToList();
            }
        }

        public Student GetOne(Expression<Func<Student, bool>> filter)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                return context.Set<Student>().Where(filter).SingleOrDefault();
            }
        }

        public void Update(Student entity)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var updatedEntity = context.Update(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
