using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Entities.Models
{
    public class Topping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
