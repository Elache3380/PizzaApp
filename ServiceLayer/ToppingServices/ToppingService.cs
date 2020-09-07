using Microsoft.EntityFrameworkCore;
using PizzaApp.Data.Data;
using PizzaApp.Entities.Models;
using PizzaApp.ServiceLayer.ToppingServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.ServiceLayer.ToppingServices
{
    public class ToppingService : IToppingService
    {
        private readonly PizzaAppContext _pizzaAppContext;
        public ToppingService(PizzaAppContext pizzaAppContext)
        {
            _pizzaAppContext = pizzaAppContext;
        }

        public async Task<IReadOnlyCollection<ToppingDto>> GetAllToppingsAsync()
        {

            var toppings = _pizzaAppContext.Toppings
                .AsNoTracking()
                .Include(t => t.PizzaToppings).ThenInclude(pt => pt.Pizza)
                .Select(t => new ToppingDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Pizzas = (ICollection<Pizza>)t.PizzaToppings.Select(pt => pt.Pizza != null).ToList()
                }); 
                
            return await toppings.ToListAsync();
        }

        public async Task<ToppingDto> GetToppingAsync(int id)
        {
            var topping = _pizzaAppContext.Toppings
                .AsNoTracking()
                .Include(t => t.PizzaToppings).ThenInclude(pt => pt.Pizza)
                .Select(p => new ToppingDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Pizzas = p.PizzaToppings.Where(pt => pt.ToppingId == id).Select(pt => pt.Pizza).ToList()
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            return await topping;
        }

        public Task PostToppingAsync(Topping topping)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateToppingAsync(Topping topping)
        {
            _pizzaAppContext.Entry(topping).State = EntityState.Modified;
            await _pizzaAppContext.SaveChangesAsync();
        }

        public async Task DeleteToppingAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id not found.");
            }

            var topping = _pizzaAppContext.Toppings
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (topping == null)
            {
                throw new ArgumentNullException("Pizza not found.");
            }

            _pizzaAppContext.Toppings.Remove(topping);
            await _pizzaAppContext.SaveChangesAsync();
        }
    }
}
