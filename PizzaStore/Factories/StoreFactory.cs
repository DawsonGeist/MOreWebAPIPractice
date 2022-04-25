using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Factories
{
    public static class StoreFactory
    {
        public static Store CreateRandom()
        {
            Random generator = new Random();
            Store returner = new();
            returner.ID = Guid.NewGuid().ToString();
            returner.MaxCapacity = generator.Next(5, 100);
            returner.Pepperonie = generator.Next(0, 25) * 1.0;
            returner.TopCheese = generator.Next(0, 75) * 1.0;
            returner.SizeSQFT = returner.MaxCapacity * 25 + 500;
            returner.Flour = generator.Next(0, 100);
            returner.DoughIngredient = generator.Next(0, 5);
            return returner;
        }

        public static Store CreateStore(int maxCapacity, double pepperonie, double topCheese, int sizeSQFT, double flour, double doughIngredient)
        {
            Store returner = new();
            returner.ID = Guid.NewGuid().ToString();
            returner.MaxCapacity = maxCapacity;
            returner.Pepperonie = pepperonie;
            returner.TopCheese = topCheese;
            returner.SizeSQFT = sizeSQFT;
            returner.Flour = flour;
            returner.DoughIngredient = doughIngredient;
            return returner;
        }
    }
}
