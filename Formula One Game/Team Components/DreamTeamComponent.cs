using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    abstract class DreamTeamComponent
    {
        public string Name { get; }
        public float Price { get; protected set; }

        public DreamTeamComponent(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public DreamTeamComponent(string name)
        {
            Name = name;
        }

        public int CompareTo(object obj)
        {
            DreamTeamComponent driver = (DreamTeamComponent)obj;
            int compareByPrice = -Price.CompareTo(driver.Price);
            int compareBySurname = Name.CompareTo(driver.Name);
            return compareByPrice != 0 ? compareByPrice : compareBySurname;
        }
    }
}
