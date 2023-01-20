using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAL.DataModels;
using Warehouse.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.DAL.Repositories
{
    public class WorkersRepository : IRepository<Worker>
    {

        private WarehouseDbContext db;
        //public readonly ILogger _logger;
        public WorkersRepository(WarehouseDbContext db   /*, ILogger logger*/)
        {
            this.db = db;
            //this._logger = logger;
        }
        private bool disposed = false;


        public void Create(Worker w)
        {                     
            db.Workers.Add(w);
        }

        public IEnumerable<Worker> GetList()
        {
            return db.Workers;
        }


        public virtual async Task<Worker> GetItem(long? id)
        {
            return await db.Workers.FindAsync(id);
        }


        public void Update(Worker w)
        {
            db.Entry(w).State = EntityState.Modified;
        }



        public void Delete(long id)
        {
            Worker? w = db.Workers.Find(id);
            if (w != null)
              db.Workers.Remove(w);
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


        public void Save()
        {
            db.SaveChanges();
        }

    }
}
