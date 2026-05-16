using Learning.Models;

namespace Learning.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> categories { get; }
        IRepository<Item> items { get; }
        IRepository<Employee> employees { get; }
        int Commit();
    }
}
