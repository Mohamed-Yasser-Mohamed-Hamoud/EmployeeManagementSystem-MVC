using Learning.Data;
using Learning.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Learning.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context) 
        {
            this.context = context;
        
        }
        protected AppDbContext context;
        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }   

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);

        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(params string[] agars)
        {
            IQueryable<T> query = context.Set<T>();
            if (agars.Length > 0)
            {
                foreach (var agar in agars)
                {
                    query = query.Include(agar);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agars)
        {
            IQueryable<T> query = context.Set<T>();
            if (agars.Length > 0)
            {
                foreach (var agar in agars)
                {
                    query = query.Include(agar);
                }
            }
            return await query.ToListAsync();
        }

        public void AddOne(T MyItem)
        {
            context.Set<T>().Add(MyItem);
             context.SaveChanges();
        }

        public void UpdateOne(T MyItem)
        {
            context.Set<T>().Update(MyItem);
             context.SaveChanges();
        }

        public void DeleteOne(T MyItem)
        {
            context.Set<T>().Remove(MyItem);
             context.SaveChanges();
        }

        public void AddList(IEnumerable<T> MyList)
        {
            context.Set<T>().AddRange(MyList);
             context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> MyList)
        {
           context.Set<T>().UpdateRange(MyList);
             context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> MyList)
        {
            context.Set<T>().RemoveRange(MyList);
             context.SaveChanges();
        }
    }
}
