using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiCrudCodeFirst.Models;

namespace WebApiCrudCodeFirstDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Employee> Employees { get; set; }

    }
}