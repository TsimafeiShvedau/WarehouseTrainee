using Warehouse.DAL.DataModels;
using Warehouse.DAL.Repositories.Interfaces;

namespace WarehouseTrainee.Services
{
    public class WorkerService : IWorkerService
    {
        private IRepository<Worker> _workerRepository;

        public WorkerService(IRepository<Worker> workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public void Create(Worker w)
        {
            _workerRepository.Create(w);
        }

        public void Delete(long id)
        {
            _workerRepository.Delete(id);
        }

        public IEnumerable<Worker> GetList()
        {
            return _workerRepository.GetList();
        }

        public virtual async Task<Worker> GetWorkerByID(long? id)
        {
             return await _workerRepository.GetItem(id);
        }

        public void Save()
        {
            _workerRepository.Save();
        }

        public void Update(Worker item)
        {
            _workerRepository.Update(item);
        }

        ////public void UpdateWorkersDepartment(long workerID, long depID)
        ////{
        ////    _workerRepository.UpdateWorkersDepartment(long workerID, long depID);
        ////}


    }
}
