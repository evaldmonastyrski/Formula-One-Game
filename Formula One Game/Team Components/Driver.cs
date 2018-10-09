using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Driver : DreamTeamComponent, IComparable
    {
        public string Name { get; }
        public string Surname { get; }
        public float Price { get; }

        public Driver(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public int CompareTo(object obj)
        {
            Driver driver = (Driver) obj;
            return Name.CompareTo(driver.Name);
        }

        public override string ToString()
        {
            return (Name + " " + Surname);
        }
    }
}
