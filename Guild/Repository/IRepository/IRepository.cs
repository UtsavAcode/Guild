namespace Guild.Repository.IRepository
{
    public interface IRepository<T> where T : class
    
    {


        void InsertRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        IEnumerable<T> GetAll();

        
       
    }
}
