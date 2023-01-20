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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
          if (_departmentService.GetList() == null)
          {
              return NotFound();
          }
            return _departmentService.GetList().ToList();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(long id)
        {
          if (_departmentService.GetList() == null)
          {
              return NotFound();
          }
            var department = _departmentService.GetDepartmentByID(id);

            if (department == null)
            {
                return NotFound();
            }

            return await department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(long id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _departmentService.Update(department);

            try
            {
                _departmentService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
          if (_departmentService.GetList() == null)
          {
              return Problem("Entity set 'WarehouseDbContext.Departments'  is null.");
          }
            _departmentService.Create(department);
            _departmentService.Save();

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(long id)
        {
            if (_departmentService.GetList() == null)
            {
                return NotFound();
            }
            var department = _departmentService.GetDepartmentByID(id);
            if (department == null)
            {
                return NotFound();
            }

            _departmentService.Delete(id);
            _departmentService.Save();

            return NoContent();
        }

        private bool DepartmentExists(long id)
        {
            return _departmentService.GetDepartmentByID(id) != null ? true : false;
        }
    }
}
