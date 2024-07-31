using Infraestructure.Context;
using Domain.Models;
using APICodigoEFC.Response;
using APICodigoEFC.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Services.Services;

namespace APICodigoEFC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly CodigoContext _context;
        private DetailsService _service;

        public DetailsController(CodigoContext context)
        {
            _context = context;
            _service = new DetailsService(_context);
        }

        [HttpGet]
        public List<Detail> GetByFilters(string? customerName, string? invoiceNumber)
        {
            var details =_service.GetByFilters(customerName, invoiceNumber);


            return details;
        }

        [HttpGet]
        public List<Detail> Get()
        {
            var details = _service.Get();


            return details;
        }

        [HttpPost]
        public void Insert([FromBody] Detail detail)
        {
            _service.Insert(detail);
        }

        /*
        

        
        //Listar todos los detalles y buscar por nombre de cliente.
        


        [HttpGet]
        public List<DetailResponseV1> GetByInvoiceNumber(string? invoiceNumber)
        {

            IQueryable<Detail> query = _context.Details
                .Include(x => x.Product)
                .Include(x => x.Invoice)
                .Where(x => x.IsActive);
            if (!string.IsNullOrEmpty(invoiceNumber))
                query = query.Where(x => x.Invoice.Number.Contains(invoiceNumber));

            //Todos los detalles del modelo
            var details = query.ToList();
         

            //Convertir modelo al response
            var response = details
                           .Select(x => new DetailResponseV1                            
                           {            
                            InvoiceNumber=x.Invoice.Number,
                            ProductName=x.Product.Name,
                            SubTotal=x.SubTotal
                            }).ToList();

            return response;
        }

        [HttpGet]
        public List<DetailResponseV2> GetByInvoiceNumber2(string? invoiceNumber)
        {

            IQueryable<Detail> query = _context.Details
                .Include(x => x.Product)
                .Include(x => x.Invoice)
                .Where(x => x.IsActive);
            if (!string.IsNullOrEmpty(invoiceNumber))
                query = query.Where(x => x.Invoice.Number.Contains(invoiceNumber));

            //Todos los detalles del modelo
            var details = query.ToList();


            //Convertir modelo al response
            var response = details
                           .Select(x => new DetailResponseV2
                           {
                               InvoiceNumber = x.Invoice.Number,
                               ProductName = x.Product.Name,
                               Amount = x.Amount,
                               Price=x.Price,
                               IGV=x.Amount*x.Price*Constants.IGV
                           }).ToList();

            return response;
        }
        */
    }
}
