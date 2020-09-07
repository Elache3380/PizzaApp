using PizzaApp.Entities.Models;
using PizzaApp.ServiceLayer.ToppingServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.ServiceLayer.PizzaServices.TransfertObjects
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Topping> Toppings { get; set; }
    }
}
