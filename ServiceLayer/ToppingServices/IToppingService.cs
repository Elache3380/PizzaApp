using PizzaApp.Entities.Models;
using PizzaApp.ServiceLayer.ToppingServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.ServiceLayer.ToppingServices
{
    public interface IToppingService
    {
        Task<IReadOnlyCollection<ToppingDto>> GetAllToppingsAsync();
        Task<ToppingDto> GetToppingAsync(int id);
        Task PostToppingAsync(Topping topping);
        Task UpdateToppingAsync(Topping topping);
        Task DeleteToppingAsync(int? id);
    }
}
