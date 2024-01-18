using System.Linq.Expressions;

namespace Guild.Repository.IRepository
{
    public interface IRepository <T> where T : class 
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        public T FindById(int id);
    }
}
