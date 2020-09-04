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
            throw new NotImplementedException();
        }
    }
}
