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
        public float price;

        public DreamTeam(Driver driver1, Driver driver2, Team team, Engine engine)
        {
            Driver1 = driver1;
            Driver2 = driver2;
            Team = team;
            Engine = engine;
            price = CalculatePrice();
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

        public float CalculatePrice()
        {
            return 0F;
        }

        public int CompareTo(object obj)
        {
            DreamTeam dreamTeam = (DreamTeam) obj;
            return this.ToString().CompareTo(dreamTeam.ToString());
        }

        public override string ToString()
        {
            return (Driver1.ToString() + " " + Driver2.ToString() + " " + Team.ToString() + " " + Engine.ToString());
        }
    }
}
