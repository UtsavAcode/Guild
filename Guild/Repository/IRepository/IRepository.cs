using System.Linq.Expressions;

namespace Guild.Repository.IRepository
{
    public interface IRepository<T> where T : class
    
    {

        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> filter);
        public T FindById(int Id);

        


    }
}
