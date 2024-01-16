using System.Linq.Expressions;

namespace Guild.Repository.IRepository
{
    //While we are working with the generic we wont know what the class type will be.
    //Generic is used to store different types of data we will work with.
    //T will denote the generic class.

    public interface IRepository<T> where T : class
    {
        ///| The class is parameterized with a type parameter T that is constrained to be a reference type     |
        //| (class). This allows the class to work with any entity type that is mapped to the underlying      |
        //| database using Entity Framework.


        //To get all the data we use IEnumerable which will present all the data in a list format.

        IEnumerable<T> GetAll();

        //If we have to get the data of only one category to edit or display it on the screen.
        T Get(Expression<Func<T, bool>> filter);

        //Creating the method to add a data.
        void Add(T entity);

        //Method to delete.
        void Delete(T entity);

        //Method to Update.
       // void Update(T entity);

        //Method to delete multiple entities in a single column.
        void DeleteRange(IEnumerable<T> entity);

        //This is the method to delete the data in through the ID.

    }
}
