using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    public class Stores
    {
        public List<Store> stores = new List<Store>();
        private Stores()
        {
        }
        private static Stores _instance;
        public static Stores GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Stores();
            }
            return _instance;
        }

        public void AddStore(Store store)
        {
            stores.Add(store);
        }
      
    }
}
