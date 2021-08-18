using AddressRegistration.Data;
using AddressRegistration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegistration.Services
{
    public class ProductService : IProductService
    {
        ApplicationDbContext dbContext;
        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await dbContext.Product.ToListAsync();
        }

        List<Product> IProductService.GetAllProducts()
        {
            return dbContext.Product.ToList();
        }
    }
}
