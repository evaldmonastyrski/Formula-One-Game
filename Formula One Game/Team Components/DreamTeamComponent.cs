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
        private float points;
        public float priceChange;

        public DreamTeamComponent(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public DreamTeamComponent(string name)
        {
            Name = name;
        }

        public float Points
        {
            get { return RoundFloat.roundTo2(points); }
            set { this.points = value; }
        }

        public float PriceChange
        {
            get { return RoundFloat.roundTo2(priceChange); }
            set { this.priceChange = value; }
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
