using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Engine : DreamTeamComponent, IComparable
    {
        private string name;
        public List<Driver> drivers;

        public Engine(string name)
        {
            this.name = name;
            drivers = new List<Driver>();
        }

        public void addDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public int CompareTo(object obj)
        {
            Engine engine = (Engine)obj;
            return name.CompareTo(engine.name);
        }

        public override string ToString()
        {
            return (name).Replace("_", " ");
        }
    }
}
