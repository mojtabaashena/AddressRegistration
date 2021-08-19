using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressRegistration.Data;
using AddressRegistration.Models;
using AddressRegistration.ViewModel;

namespace AddressRegistration.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Services.IProductService _productService;
        private readonly Services.ICustomerService _customerService;

        public CustomersController(ApplicationDbContext context, Services.IProductService productService,Services.ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
            _productService = productService;
        }

        // GET: Customers
        public async Task<IActionResult> Index(int Page=1 , int Limit=1000)
        {
            List <Customer> customer = await _context.Customer.Include(c => c.Products).ToListAsync();
            //var customer =await _customerService.GetAsync(Page, Limit); 
            return View(customer);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.Include( c => c.Products).FirstOrDefaultAsync(m => m.id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            CustomerViewModel customer = new CustomerViewModel();
            customer.Products = _productService.GetCustomerProducts(); 
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Bind("id,Name,PhoneNumber,Address,PostalCode,Descrip,dateTime,Products")] Customer
        public async Task<IActionResult> Create(ViewModel.CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                customer.id = Guid.NewGuid();

                Customer newCust = new Customer() { id = customer.id, Name = customer.Name, PhoneNumber = customer.PhoneNumber, Address = customer.Address, Descrip = customer.Descrip, dateTime = customer.dateTime, PostalCode = customer.PostalCode};

                List<Data.Entities.Product> products = new List<Data.Entities.Product> (); 
                foreach (var item in customer.Products)
                {
                    if (item.IsSelected)
                    {
                        Data.Entities.Product product = _context.Product.FirstOrDefault( p => p.id == item.id);
                        products.Add(product);
                    }
                }

                if (products.Count > 0)
                    newCust.Products = products;
                _context.Add(newCust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);

             
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.Include(c => c.Products).FirstOrDefaultAsync(m => m.id == id);
            if (customer == null)
            {
                return NotFound();
            }

            CustomerViewModel vcustomer = new CustomerViewModel() { id= customer.id, Name = customer.Name, Address=customer.Address, PostalCode = customer.PostalCode, dateTime = customer.dateTime, Descrip = customer.Descrip, PhoneNumber= customer.PhoneNumber};
            vcustomer.Products = _productService.GetCustomerProducts();

            foreach (var item in customer.Products)
            {
                vcustomer.Products.FirstOrDefault(p => p.id == item.id).IsSelected = true; 
            }
            

            return View(vcustomer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ViewModel.CustomerViewModel customer)
        {
            if (id != customer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Customer dbCust = await _context.Customer.Include(c => c.Products).FirstOrDefaultAsync(m => m.id == id);

                    dbCust.Name = customer.Name; dbCust.PhoneNumber = customer.PhoneNumber; dbCust.Address = customer.Address; dbCust.Descrip = customer.Descrip; dbCust.dateTime = customer.dateTime; dbCust.PostalCode = customer.PostalCode ;

                    //List<Data.Entities.Product> products = new List<Data.Entities.Product>();

                    foreach (var item in customer.Products)
                    {
                        if (item.IsSelected)
                        {
                            if (!dbCust.Products.Any(c => c.id == item.id))
                            {
                                Data.Entities.Product product = _context.Product.FirstOrDefault(p => p.id == item.id);
                                dbCust.Products.Add(product);
                            }
                        }
                        else
                        {
                            if (dbCust.Products.Any(c => c.id == item.id))
                            {
                                dbCust.Products.Remove(dbCust.Products.FirstOrDefault(p => p.id == item.id));
                            }
                        }
                    }

                    //if (products.Count > 0)
                     //   newCust.Products. = products;

                    _context.Update(dbCust);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = await _context.Customer.Include( c => c.Products).FirstOrDefaultAsync(m => m.id == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customer.Any(e => e.id == id);
        }
    }
}
