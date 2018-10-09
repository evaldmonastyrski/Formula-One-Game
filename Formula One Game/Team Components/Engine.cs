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

        public Engine(string name)
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
            Engine engine = (Engine)obj;
            return Name.CompareTo(engine.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
