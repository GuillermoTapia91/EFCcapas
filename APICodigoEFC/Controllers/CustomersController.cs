using APICodigoEFC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CodigoContext _context;

        public CustomersController(CodigoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Customer> GetByFilters(string? name,string? documentNumber )
        {
            var query = _context.Customers.Where(
                                            x => x.Name.Contains(name.Trim()) ||
                                            x.DocumentNumber.Contains(documentNumber.Trim()));
            return query.ToList();
        }

        [HttpPost]
        public void Insert([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }


    }
}
