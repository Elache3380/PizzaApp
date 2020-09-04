using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Data.ModelsConfiguration
{
    public class ToppingConfiguration : IEntityTypeConfiguration<Topping>
    {
        public void Configure(EntityTypeBuilder<Topping> builder)
        {
            builder.HasMany(t => t.PizzaToppings)
               .WithOne(pt => pt.Topping)
               .HasForeignKey(pt => pt.ToppingId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Name).HasMaxLength(250);
        }
    }
}
