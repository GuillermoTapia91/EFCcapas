using APICodigoEFC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly CodigoContext _context;

        public DetailsController(CodigoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert([FromBody] Detail detail)
        {
            _context.Details.Add(detail);
            _context.SaveChanges();
        }

        [HttpGet]
        public List<Detail> Get()
        {
            IQueryable<Detail> query = _context.Details
                .Include(x => x.Product)
                .Include(x => x.Invoice).ThenInclude(y => y.Customer)
                .Where(x => x.IsActive);


            return query.ToList();
        }
        //Listar todos los detalles y buscar por nombre de cliente.
        [HttpGet]
        public List<Detail> GetByFilters(string? customerName, string? invoiceNumber)
        {
            IQueryable<Detail> query = _context.Details
               .Include(x => x.Product)
               .Include(x => x.Invoice).ThenInclude(y => y.Customer)
               .Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(customerName))
                query = query.Where(x => x.Invoice.Customer.Name.Contains(customerName));
            if (!string.IsNullOrEmpty(invoiceNumber))
                query = query.Where(x => x.Invoice.Number.Contains(invoiceNumber));


            return query.ToList();
        }
    }
}
