using PizzaApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.ServiceLayer.ToppingServices.TransfertObjects
{
    public class ToppingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pizza> Pizzas {get;set;}
    }
}
