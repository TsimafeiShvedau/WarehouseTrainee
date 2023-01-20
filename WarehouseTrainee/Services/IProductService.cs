
using Warehouse.DAL.DataModels;

namespace WarehouseTrainee.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetList();
        Task<Product> GetProductByID(long? id); // получение одного объекта по id
        void Create(Product item); // создание объекта
        void Update(Product item); // обновление объекта
        void Delete(long id); // удаление объекта по id
        void Save();  // сохранение изменений

    }
}
