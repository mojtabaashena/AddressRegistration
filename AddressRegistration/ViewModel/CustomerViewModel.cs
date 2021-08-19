using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressRegistration.ViewModel
{
    public class CustomerViewModel
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Descrip { get; set; }
        public DateTime dateTime { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
