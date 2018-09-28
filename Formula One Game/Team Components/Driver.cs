using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Driver : DreamTeamComponent, IComparable
    {
        private string name;
        private string surname;

        public Driver(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public int CompareTo(object obj)
        {
            Driver driver = (Driver) obj;
            return name.CompareTo(driver.name);
        }

        public override string ToString()
        {
            return (name + " " + surname);
        }
    }
}
