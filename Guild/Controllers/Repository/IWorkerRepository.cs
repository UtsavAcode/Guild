namespace Guild.Controllers.Repository
{
    //The interface will have generic data type.
    //This will help to use different types of data.
    public interface IWorkerRepository <T> where T : class
    {
        //IEnumerable will make a list of our data.
        IEnumerable<T> GetData ();

        //For Adding the data and it has no return type.
        public void InsertData (T Classname);

        //Getting data by id for a single data or view.
        T GetDataById (int Id);

        //For Updating the data.
        void UpdateDataById(T Classname);

        //For Deleting the data
        void DeleteDataById (int Id);

        //For saving the data.
        void SaveData();
    }
}
