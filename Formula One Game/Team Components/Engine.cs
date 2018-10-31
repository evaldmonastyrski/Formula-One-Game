using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Engine : DreamTeamComponent, IComparable
    {
        public List<Driver> drivers;

        public Engine(string name)
            : base(name)
        {
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

        public override string ToString()
        {
            return Name;
        }
    }
}
