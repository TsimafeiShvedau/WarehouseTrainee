using Warehouse.DAL.DataModels;

namespace WarehouseTrainee.Services
{
    public interface IWorkerService
    {
        IEnumerable<Worker> GetList();
        Task<Worker> GetWorkerByID(long? id); // получение одного объекта по id
        void Create(Worker item); // создание объекта
        void Update(Worker item); // обновление объекта
        void Delete(long id); // удаление объекта по id
        void Save();  // сохранение изменений

    }
}
