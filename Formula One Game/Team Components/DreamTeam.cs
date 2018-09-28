using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class DreamTeam : IComparable
    {
        private Driver driver1;
        private Driver driver2;
        private Team team;
        private Engine engine;

        public DreamTeam(Driver driver1, Driver driver2, Team team)
        {
            this.driver1 = driver1;
            this.driver2 = driver2;
            this.team = team;
        }

        public string getDriver1Name()
        {
            return driver1.ToString();
        }

        public string getDriver2Name()
        {
            return driver2.ToString();
        }

        public string getTeamName()
        {
            return team.ToString();
        }

        public string getEngineName()
        {
            return engine.ToString();
        }

        public int CompareTo(object obj)
        {
            DreamTeam dreamTeam = (DreamTeam) obj;
            return this.ToString().CompareTo(dreamTeam.ToString());
        }

        public override string ToString()
        {
            return (driver1.ToString() + " " + driver2.ToString() + " " + team.ToString());
        }
    }
}
