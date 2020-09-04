using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Data.ModelsConfiguration
{
    public class PizzaToppingConfiguration : IEntityTypeConfiguration<PizzaTopping>
    {
        public void Configure(EntityTypeBuilder<PizzaTopping> builder)
        {
            builder.HasKey(key => new { key.PizzaId, key.ToppingId });

            builder.HasOne(pt => pt.Pizza)
                .WithMany(p => p.PizzaToppings)
                .HasForeignKey(pt => pt.PizzaId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.Topping)
                .WithMany(t => t.PizzaToppings)
                .HasForeignKey(pt => pt.ToppingId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
