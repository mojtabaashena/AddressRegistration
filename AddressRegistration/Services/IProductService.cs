using AddressRegistration.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegistration.Services
{
    public interface IProductService 
    {
        public Task<List<Product>> GetAllProductsAsync();

        public List<Product> GetAllProducts();
    }
}
