using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class DreamTeam : IComparable
    {
        private Driver Driver1;
        private Driver Driver2;
        private Team Team;
        private Engine Engine;
        public float Price { get; }

        public DreamTeam(Driver driver1, Driver driver2, Team team, Engine engine, float budget)
        {
            Driver1 = driver1;
            Driver2 = driver2;
            Team = team;
            Engine = engine;
            Price = calculatePrice();
        }

        public string GetDriver1Surname()
        {
            return Driver1.Surname;
        }

        public string GetDriver2Surname()
        {
            return Driver2.Surname;
        }

        public string GetTeamName()
        {
            return Team.Name;
        }

        public string GetEngineName()
        {
            return Engine.Name;
        }

        public int CompareTo(object obj)
        {
            DreamTeam dreamTeam = (DreamTeam) obj;
            int compareByPrice = -Price.CompareTo(dreamTeam.Price);
            int compareByName = this.ToString().CompareTo(dreamTeam.ToString());
            return compareByPrice != 0 ? compareByPrice : compareByName;
        }

        public override string ToString()
        {
            return (Driver1.ToString() + " " + Driver2.ToString() + " " + Team.ToString() + " " + Engine.ToString());
        }

        private float calculatePrice()
        {
            return Driver1.Price + Driver2.Price;
        }
    }
}
