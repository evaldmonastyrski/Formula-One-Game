using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Driver : DreamTeamComponent, IComparable
    {
        public string Surname { get; }

        public Driver(string name, string surname, float price)
            : base (name, price)
        {
            Surname = surname;
        }

        public override string ToString()
        {
            return (Name + " " + Surname);
        }
    }
}
