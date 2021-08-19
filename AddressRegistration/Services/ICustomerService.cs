using AddressRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegistration.Services
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAsync(int Page = 1, int Limit = 10);
    }
}
