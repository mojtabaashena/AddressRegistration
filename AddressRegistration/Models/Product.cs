using AddressRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegistration.Data.Entities
{
    public class Product
    {
        public Guid id { get; set; }
        public string ProductName { get; set; }
        public int? Priority { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public string Descrip { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
