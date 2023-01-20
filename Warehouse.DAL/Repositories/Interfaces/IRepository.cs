using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DAL.Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable
            where T : class
    {

        IEnumerable<T> GetList(); // получение всех объектов
        Task<T> GetItem(long? id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(long id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
