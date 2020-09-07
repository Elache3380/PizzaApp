using Microsoft.EntityFrameworkCore;
using PizzaApp.Data.Data;
using PizzaApp.Entities.Models;
using PizzaApp.ServiceLayer.PizzaServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.ServiceLayer.PizzaServices
{
    public class PizzaService : IPizzaService
    {
        private readonly PizzaAppContext _pizzaAppContext;
        public PizzaService(PizzaAppContext pizzaAppContext)
        {
            _pizzaAppContext = pizzaAppContext;
        }

        public async Task<IReadOnlyCollection<PizzaDto>> GetAllPizzasAsync()
        {
            var pizzas = _pizzaAppContext.Pizzas
                .AsNoTracking()
                .Include(t => t.PizzaToppings).ThenInclude(pt => pt.Topping)
                .Select(p => new PizzaDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Toppings = (ICollection<Topping>)p.PizzaToppings.Select(pt => pt.Topping != null).ToList()
                });

            return await pizzas.ToListAsync();
        }
        public async Task<PizzaDto> GetPizzaAsync(int id)
        {
            var pizza = _pizzaAppContext.Pizzas
                .AsNoTracking()
                .Include(t => t.PizzaToppings).ThenInclude(pt => pt.Topping)
                .Select(p => new PizzaDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Toppings = p.PizzaToppings.Where(pt => pt.PizzaId == id).Select(pt => pt.Topping).ToList()
                })
                .FirstOrDefaultAsync(p => p.Id == id);

                return await pizza;
        }
        public async Task PostPizzaAsync(Pizza pizza)
        {
            if (pizza == null)
            {
                throw new ArgumentNullException();
            }
            _pizzaAppContext.Pizzas.Add(pizza);
            await _pizzaAppContext.SaveChangesAsync();
        }
        public async Task UpdatePizzaAsync(Pizza pizza)
        {
            _pizzaAppContext.Entry(pizza).State = EntityState.Modified;
            await _pizzaAppContext.SaveChangesAsync();
        }

        public async Task DeletePizzaAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id not found.");
            }

            var pizza = _pizzaAppContext.Pizzas
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (pizza == null)
            {
                throw new ArgumentNullException("Pizza not found.");
            }

            _pizzaAppContext.Pizzas.Remove(pizza);
            await _pizzaAppContext.SaveChangesAsync();
        }
    }
}
