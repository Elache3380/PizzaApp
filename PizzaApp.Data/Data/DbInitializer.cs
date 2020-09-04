using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Data.Data
{
    public class DbInitializer
    {
        public static void Initialize(PizzaAppContext context)
        {
            context.Database.EnsureCreated();
        }

    }
}
