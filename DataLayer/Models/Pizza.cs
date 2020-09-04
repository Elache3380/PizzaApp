using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Entities.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
