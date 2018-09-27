using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Engine : DreamTeamComponent
    {
        private string name;
        private List<Driver> drivers;

        public Engine(string name)
        {
            this.name = name;
            drivers = new List<Driver>();
        }
    }
}
