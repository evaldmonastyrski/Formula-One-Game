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

        public Driver(string name, string surname, float price)
        {
            Name = name;
            Surname = surname;
            Price = price;
        }

        public int CompareTo(object obj)
        {
            Driver driver = (Driver) obj;
            return Price.CompareTo(driver.Price);
        }

        public override string ToString()
        {
            return (Name + " " + Surname);
        }
    }
}
