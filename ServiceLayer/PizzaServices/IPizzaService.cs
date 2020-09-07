using Microsoft.EntityFrameworkCore.Infrastructure;
using PizzaApp.Entities.Models;
using PizzaApp.ServiceLayer.PizzaServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.ServiceLayer.PizzaServices
{
    public interface IPizzaService
    {
        Task<IReadOnlyCollection<PizzaDto>> GetAllPizzasAsync();
        Task<PizzaDto> GetPizzaAsync(int id);
        Task PostPizzaAsync(Pizza pizza); 
        //TODO : Le pilote ici est un pilote idenique à la Db, 
        //or, ce pilote vient du consommateur, ne dois-je pas en faire un Dto?
        Task UpdatePizzaAsync(Pizza pizza);
        Task DeletePizzaAsync(int? id);
    }
}
