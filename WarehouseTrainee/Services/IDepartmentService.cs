using Warehouse.DAL.DataModels;

namespace WarehouseTrainee.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetList();
        Task<Department> GetDepartmentByID(long? id); // получение одного объекта по id
        void Create(Department item); // создание объекта
        void Update(Department item); // обновление объекта
        void Delete(long id); // удаление объекта по id
        void Save();  // сохранение изменений

    }
}
