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
    public class DepartmentsRepository : IRepository<Department>
    {
        private WarehouseDbContext db;

        public DepartmentsRepository(WarehouseDbContext db)
        {
            this.db = db;
        }
        private bool disposed = false;

        public void Delete(long id)
        {
            Department? d = db.Departments.Find(id);
            if (d != null)
                db.Departments.Remove(d);
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

        public virtual async Task<Department> GetItem(long? id)
        {
            return await db.Departments.FindAsync(id);
        }

        public IEnumerable<Department> GetList()
        {
            return db.Departments.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Department d)
        {
            db.Entry(d).State = EntityState.Modified;
        }

        public void Create(Department d)
        {
            db.Departments.Add(d);
        }
    }
}
