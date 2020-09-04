using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Data.ModelsConfiguration
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasMany(p => p.PizzaToppings)
                .WithOne(pt => pt.Pizza)
                .HasForeignKey(pt => pt.PizzaId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Name).HasMaxLength(250);
        }
    }
}
