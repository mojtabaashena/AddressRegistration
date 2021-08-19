using AddressRegistration.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegistration.ViewComponents
{
    public class SelectProductViewComponent : ViewComponent
    {
        IProductService productService;
        public SelectProductViewComponent(IProductService productService )
        {
            this.productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            return View(productService.GetCustomerProducts()); 
        }
    }
}
