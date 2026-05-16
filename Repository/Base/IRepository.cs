using System.Linq.Expressions;

namespace Learning.Repository.Base
{
    public interface IRepository <T> where T : class
    {
        T FindById(int id);

        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(params string[] egars);

        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> FindAllAsync();
        T SelectOne (Expression<Func<T, bool>> match );
        Task<IEnumerable<T>> FindAllAsync(params string[] egars);
        void AddOne(T MyItem);
        void UpdateOne(T MyItem);
        void DeleteOne(T MyItem);
        void AddList(IEnumerable<T> MyList);
        void UpdateList(IEnumerable<T> MyList);
        void DeleteList(IEnumerable<T> MyList);

    }
}
