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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
          if (_productService.GetList() == null)
          {
              return NotFound();
          }
            return _productService.GetList().ToList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
          if ( _productService.GetList() == null)
          {
              return NotFound();
          }
            var product = _productService.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return await product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _productService.Update(product);

            try
            {
                 _productService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(string prName, long depID)
        {
          if (_productService.GetList() == null)
          {
              return Problem("Entity set 'WarehouseDbContext.Products'  is null.");
          }
            Product P = new Product();
            P.Name = prName;
            P.DepartmentId = depID;
            _productService.Create(P);
            _productService.Save();

            return CreatedAtAction("GetProduct", new { id = P.Id }, P);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            if (_productService.GetList() == null)
            {
                return NotFound();
            }
            var product = _productService.GetProductByID(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.Delete(id);
            _productService.Save();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _productService.GetProductByID(id) != null ? true : false;
        }
    }
}
