using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAL.Data;
using Warehouse.DAL.DataModels;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.DAL.Repositories
{
    public class ProductsRepository : IRepository<Product>
    {
        private WarehouseDbContext db;

        public ProductsRepository(WarehouseDbContext db)
        {
            this.db = db;
        }
        private bool disposed = false;

        

        public void Create(Product item)
        {
            db.Products.Add(item);
            
        }

        public void Delete(long id)
        {
            Product? p = db.Products.Find(id);
            if (p != null)
                db.Products.Remove(p);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<Product> GetItem(long? id)
        {
            return await db.Products.FindAsync(id);
        }

        public IEnumerable<Product> GetList()
        {
            return db.Products.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Product p)
        {
            db.Entry(p).State = EntityState.Modified;
        }
    }
}
