﻿using Domain.Models;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DetailsService
    {
        private readonly CodigoContext _context;
        public DetailsService(CodigoContext context)
        {
            _context = context;
        }


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

        
        public List<Detail> Get()
        {
            IQueryable<Detail> query = _context.Details
                .Include(x => x.Product)
                .Include(x => x.Invoice).ThenInclude(y => y.Customer)
                .Where(x => x.IsActive);


            return query.ToList();
        }

        public void Insert( Detail detail)
        {
            _context.Details.Add(detail);
            _context.SaveChanges();
        }


    }
}
