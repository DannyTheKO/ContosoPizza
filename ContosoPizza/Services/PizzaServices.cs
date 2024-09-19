using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public static class PizzaServices
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaServices() // This will create a Pizzas array list
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false},
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true},
            };
        }

        // The GetAll method is a static method that returns a list of all Pizza objects in the Pizzas collection.
        // It does not take any parameters and simply returns the entire Pizzas list.
        public static List<Pizza> GetAll() => Pizzas;

        // Get specific id method pass though parameter
        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id); 
        
        // Get specific id method pass though parameter
        public static Pizza? GetByName(string pizza_name) => Pizzas.FirstOrDefault(n => n.Name == pizza_name);

        // Add Pizza into the Pizzas array
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza); 
        }

        // Delete id inside of Pizzas array
        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        // Update Pizza using Id to specify
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;
                
            Pizzas[index] = pizza;
        }
    }
}
