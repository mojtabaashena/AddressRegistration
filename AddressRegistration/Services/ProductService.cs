using AddressRegistration.Data;
using AddressRegistration.Data.Entities;
using AddressRegistration.ViewModel;
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

        public List<ProductViewModel> GetCustomerProducts()
        {
            List<Product> product = dbContext.Product.ToList();

            List<ProductViewModel> CustomerProducts = new List<ProductViewModel>();

            foreach (var item in product)
            {
                CustomerProducts.Add(new ProductViewModel() { id = item.id, ProductName = item.ProductName, IsSelected = false }); 
            }

            return CustomerProducts;

        }

        List<Product> IProductService.GetAllProducts()
        {
            return dbContext.Product.ToList();
        }
    }
}
