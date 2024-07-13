using APICodigoEFC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CodigoContext _context;

        public ProductsController(CodigoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetByFilters(string? name)
        {
            IQueryable<Product> query = _context.Products.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            return query.ToList();
        }

        [HttpPost]
        public void Insert([FromBody] Product Product)
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
        }
        [HttpPut]
        public void Update([FromBody] Product Product)
        {
            _context.Entry(Product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Product = _context.Products.Find(id);
            Product.IsActive = false;
            _context.Entry(Product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
