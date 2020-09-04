using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PizzaApp.Data.ModelsConfiguration;
using PizzaApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Data.Data
{
    public class PizzaAppContext : DbContext
    {
        public PizzaAppContext(DbContextOptions<PizzaAppContext> options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaTopping> PizzaToppings {get;set;}
        public DbSet<Topping> Toppings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().ToTable("Pizza");
            modelBuilder.Entity<PizzaTopping>().ToTable("PizzaTopping");
            modelBuilder.Entity<Topping>().ToTable("Topping");


            modelBuilder.ApplyConfiguration(new PizzaConfiguration());
            modelBuilder.ApplyConfiguration(new ToppingConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaToppingConfiguration());

        }
    }
}
