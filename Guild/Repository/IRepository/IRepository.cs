namespace Guild.Repository.IRepository
{
    public interface IRepository<T> where T : class
    
    {

        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        
        
       
    }
}
