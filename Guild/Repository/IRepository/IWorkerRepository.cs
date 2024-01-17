using Guild.Models;
using Guild.Models.Domain;

namespace Guild.Repository.IRepository
{
    //Now the class we will be using is the model that we want to use for the repository.
    public interface IWorkerRepository : IRepository<worker>
    {
        void Update(worker obj);

       /* void UpdateWorker(worker obj);*/
        void Save();


        void DeleteById(int Id);

        //This is the method to get the data by ID.
        //public worker GetById(int Id);
        worker GetById(int Id);
    }
}
