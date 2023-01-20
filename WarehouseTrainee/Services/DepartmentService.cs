using Warehouse.DAL.DataModels;
using Warehouse.DAL.Repositories.Interfaces;

namespace WarehouseTrainee.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Create(Department d)
        {
            _departmentRepository.Create(d);
        }

        public void Delete(long id)
        {
            _departmentRepository.Delete(id);
        }

        public virtual async  Task<Department> GetDepartmentByID(long? id)
        {
            return await _departmentRepository.GetItem(id);
        }

        public IEnumerable<Department> GetList()
        {
            return _departmentRepository.GetList();
        }

        public void Save()
        {
            _departmentRepository.Save();
        }

        public void Update(Department item)
        {
            _departmentRepository.Update(item);
        }
    }
}
