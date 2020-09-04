using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Data.Data
{
    public class PizzaAppContextFactory : IDesignTimeDbContextFactory<PizzaAppContext>
    {
        public PizzaAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaAppContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");

            return new PizzaAppContext(optionsBuilder.Options);
        }
    }
}
