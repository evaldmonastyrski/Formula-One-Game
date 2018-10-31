using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Engine : DreamTeamComponent, IComparable
    {
        public String Name { get; }
        public List<Driver> drivers;
        public float Price { get; private set; }

        public Engine(string name)
        {
            Name = name;
            drivers = new List<Driver>();
        }

        public void SetPrice()
        {
            Price = Constants.ENGINE_PRICE_RATIO * drivers.Sum(Driver => Driver.Price); 
        }

        public void AddDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public int CompareTo(object obj)
        {
            Engine engine = (Engine)obj;
            int compareByPrice = -Price.CompareTo(engine.Price);
            int compareByName = Name.CompareTo(engine.Name);
            return compareByPrice != 0 ? compareByPrice : compareByName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
