using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class GameArea
    {
        private DataDeserializer theDataDeserializer;
        private HashSet<Driver> drivers;
        private HashSet<Team> teams;
        private HashSet<Engine> engines;

        public void addDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public GameArea()
        {
            drivers = new HashSet<Driver>();
            teams = new HashSet<Team>();
            engines = new HashSet<Engine>();
            theDataDeserializer = new DataDeserializer(this);
            theDataDeserializer.initializeDreamTeamComponents();

            foreach (var driver in drivers)
            {
                Console.WriteLine(driver.ToString());
            }
        }
    }
}
