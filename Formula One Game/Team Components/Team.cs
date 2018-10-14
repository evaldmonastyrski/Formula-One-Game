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

        public Team(string name)
        {
            Name = name;
            drivers = new List<Driver>();
        }

        public void AddDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public int CompareTo(object obj)
        {
            Team team = (Team)obj;
            return Name.CompareTo(team.Name);
        }

        public override string ToString()
        {
            return Name.Replace("_", " ");
        }
    }
}
