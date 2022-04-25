using PizzaStore.Factories;

namespace PizzaStore
{
    public class StoreDb 
    {
        public static List<Store> _stores = new List<Store>()
        {
            StoreFactory.CreateRandom(),
            StoreFactory.CreateRandom(),
            StoreFactory.CreateRandom(),
            StoreFactory.CreateRandom(),
            StoreFactory.CreateRandom(),
        };

        public static List<Store> GetStores()
        {
            return _stores;
        }

        public static Store GetStore(string id)
        {
            return _stores.SingleOrDefault(store => store.ID == id);
        }

        public static Store CreateStore(Store store)
        {
            _stores.Add(store);
            return store;
        }

        public static Store UpdateStore(Store update)
        {
            _stores = _stores.Select(store =>
            {
                if(store.ID == update.ID)
                {
                    store = update;
                }
                return store;
            }).ToList();
            return update;
        }

        public static void RemoveStore(string id)
        {
            _stores = _stores.FindAll(store => store.ID != id).ToList();
        }
    }
}
