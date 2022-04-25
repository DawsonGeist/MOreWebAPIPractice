namespace PizzaStore
{
    /// <summary>
    /// TODO:
    /// Learn database relationships so I can break out this massive table into tables for Inventory, Building, and Employees
    /// </summary>
    public class Store
    {
        public System.String? ID { get; set; }

        //TODO:
        //public Ingredient Ingredients { get; set; }

        public string? Address { get; set; }

        //TODO
        //public Employee Manager { get; set; }

        /// <summary>
        /// The weight of Top Cheese currently in stock
        /// </summary>
        public double TopCheese { get; set; }

        /// <summary>
        /// The weight of Pepperonie currently in stock
        /// </summary>
        public double Pepperonie { get; set; }

        /// <summary>
        /// The weight of Pepperonie currently in stock
        /// </summary>
        public double Flour { get; set; }

        /// <summary>
        /// The weight of Seasoning (that goes with flour to make dough) currently in stock
        /// </summary>
        public double DoughIngredient { get; set; }

        /// <summary>
        /// Returns the size of the store in SQFT
        /// </summary>
        public int SizeSQFT { get; set; }

        public int MaxCapacity { get; set; }

    }
}
