using AddressRegistration.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegistration.ViewModel
{
    public class ProductViewModel 
    {
        public Guid id { get; set; }
        public string ProductName { get; set; }
        public bool IsSelected { get; set; }
    }
}
