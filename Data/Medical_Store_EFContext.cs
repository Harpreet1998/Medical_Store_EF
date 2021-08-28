using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Medical_Store_EF.Models;

namespace Medical_Store_EF.Data
{
    public class Medical_Store_EFContext : DbContext
    {
        public Medical_Store_EFContext (DbContextOptions<Medical_Store_EFContext> options)
            : base(options)
        {
        }

        public DbSet<Medical_Store_EF.Models.Client> Client { get; set; }

        public DbSet<Medical_Store_EF.Models.Company> Company { get; set; }

        public DbSet<Medical_Store_EF.Models.Stock_Order> Stock_Order { get; set; }

        public DbSet<Medical_Store_EF.Models.Stock> Stock { get; set; }
    }
}
