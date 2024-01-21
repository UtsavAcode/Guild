namespace Guild.Repository.IRepository
{
    public interface IRepository<T> where T : class
    
    {
        void Insert(T entity);

        void InsertRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        List<T> List();

        IEnumerable<T> GetEnumerable();

       
    }
}
