using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Team : DreamTeamComponent, IComparable
    {
        public string Name { get; }
        private List<Driver> drivers;
        public float Price { get; private set; }

        public Team(string name)
        {
            Name = name;
            drivers = new List<Driver>();
        }

        public void SetPrice()
        {
            Price = Constants.TEAM_PRICE_RATIO * drivers.Sum(driver => driver.Price);
        }

        public void AddDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public int CompareTo(object obj)
        {
            Team team = (Team)obj;
            int compareByPrice = -Price.CompareTo(team.Price);
            int compareByName = Name.CompareTo(team.Name);
            return compareByPrice != 0 ? compareByPrice : compareByName;
        }

        public override string ToString()
        {
            return Name.Replace("_", " ");
        }
    }
}
