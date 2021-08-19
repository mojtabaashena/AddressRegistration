using AddressRegistration.Data;
using AddressRegistration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegistration.Services
{
    public class CustomerService : ICustomerService
    {
        ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetAsync(int Page = 1, int Limit = 1000)
        {
            return await _context.Customer.Include(c => c.Products).OrderByDescending(c => c.dateTime).Skip(Page - 1 * Limit).Take(Limit).ToListAsync();
        }
    }
}
