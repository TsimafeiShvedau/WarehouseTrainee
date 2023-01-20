using Warehouse.DAL.DataModels;
using Warehouse.DAL.Repositories.Interfaces;

namespace WarehouseTrainee.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productsRepository;
        public ProductService(IRepository<Product> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void Create(Product p)
        {
            _productsRepository.Create(p);
        }

        public void Delete(long id)
        {
            _productsRepository.Delete(id);
        }

        public IEnumerable<Product> GetList()
        {
            return _productsRepository.GetList();
        }

        public virtual async Task<Product> GetProductByID(long? id)
        {
            return await _productsRepository.GetItem(id);
        }

        public void Save()
        {
            _productsRepository.Save();
        }

        public void Update(Product item)
        {
            _productsRepository.Update(item);
        }
    }
}
