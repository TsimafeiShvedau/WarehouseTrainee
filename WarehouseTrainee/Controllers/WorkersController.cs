using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.DAL.Data;
using Warehouse.DAL.DataModels;
using WarehouseTrainee.Services;

namespace WarehouseTrainee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
        {
            if (_workerService.GetList() == null)
            {
                return NotFound();
            }
            return _workerService.GetList().ToList();
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(long? id)
        {
          if (id == null || _workerService.GetList == null)
          {
              return NotFound();
          }
            var worker = _workerService.GetWorkerByID(id);

            if (worker == null)
            {
                return NotFound();
            }

            return await worker;
        }

        // PUT: api/Workers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(long id, Worker worker)
        {
            if (id != worker.Id)
            {
                return BadRequest();
            }

            _workerService.Update(worker);

            try
            {
                _workerService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Workers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Worker>> PostWorker(Worker worker)
        {
          if (_workerService.GetList() == null)
          {
              return Problem("Entity set 'WarehouseDbContext.Workers'  is null.");
          }
            _workerService.Create(worker);
            _workerService.Save();

            return CreatedAtAction("GetWorker", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(long id)
        {
            if (_workerService.GetList() == null)
            {
                return NotFound();
            }
            var worker = _workerService.GetWorkerByID(id);
            if (worker == null)
            {
                return NotFound();
            }

            _workerService.Delete(id);
            _workerService.Save();

            return NoContent();
        }

        private bool WorkerExists(long id)
        {
            return _workerService.GetWorkerByID(id) != null ? true : false;
        }





    }
}
