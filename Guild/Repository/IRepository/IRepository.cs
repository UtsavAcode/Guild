namespace Guild.Repository.IRepository
{
    public interface IRepository<T> where T : class
    
    {

        public void Add(T entity);  
        void InsertRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        IEnumerable<T> GetAll();

        
       
    }
}
