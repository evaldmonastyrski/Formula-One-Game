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
        public float Points { get; private set; }
        public float PriceChange { get; private set; }

        public DreamTeam(Driver driver1, Driver driver2, Team team, Engine engine)
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

        public void CalculatePoints()
        {
            Points = Driver1.Points + Driver2.Points + Team.Points + Engine.Points;
        }

        public void CalculatePriceChange(float budget)
        {
            PriceChange = Driver1.PriceChange + Driver2.PriceChange + Team.PriceChange + Engine.PriceChange + 0.1F * (budget - Price);
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
            return Driver1.Price + Driver2.Price + Team.Price + Engine.Price;
        }
    }
}
