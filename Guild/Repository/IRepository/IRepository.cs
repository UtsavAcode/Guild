namespace Guild.Repository.IRepository
{
    //While we are working with the generic we wont know what the class type will be.
    //Generic is used to store different types of data we will work with.
    //T will denote the generic class.

    public interface IRepository<T> where T : class
    {
        //We will now declare the methods we will be using starting from the basic crud.
        //T - will be a category or any other generic model on which we want to perform CRUD.
        //or rather we want to interact with the dbContext.

        //To get all the data we use IEnumerable which will present all the data in a list format.
        
        IEnumerable<T> GetAll();

        //If we have to get the data of only one category to edit or display it on the screen.
        T GetFirstOrDefault();
    }
}
