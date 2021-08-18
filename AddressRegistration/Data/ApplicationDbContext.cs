using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AddressRegistration.Data.Entities;
using AddressRegistration.Models;

namespace AddressRegistration.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AddressRegistration.Data.Entities.Product> Product { get; set; }
        public DbSet<AddressRegistration.Models.Customer> Customer { get; set; }
    }
}
