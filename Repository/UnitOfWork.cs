using Learning.Data;
using Learning.Models;
using Learning.Repository.Base;
using Octokit;

namespace Learning.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            categories = new MainRepository<Category>(_context);
            items = new MainRepository<Item>(_context);
            employees = new MainRepository<Employee>(_context);
        }

        public IRepository<Category> categories  {get; private set;}

        public IRepository<Item> items { get; private set; }

        public IRepository<Employee> employees { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
