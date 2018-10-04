using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formula_One_Game
{
    class GameArea
    {
        private Form1 form;
        private DataDeserializer dataDeserializer;
        private SortedSet<Driver> drivers;
        private SortedSet<Team> teams;
        private SortedSet<Engine> engines;
        private Combinator combinator;

        public void addDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public void addTeam(Team team)
        {
            teams.Add(team);
        }

        public void addEngine(Engine engine)
        {
            engines.Add(engine);
        }
        public SortedSet<Driver> getDrivers()
        {
            return drivers;
        }

        public SortedSet<Team> getTeams()
        {
            return teams;
        }
        public SortedSet<Engine> getEngines()
        {
            return engines;
        }
        public GameArea(Form1 form)
        {
            this.form = form;
            drivers = new SortedSet<Driver>();
            teams = new SortedSet<Team>();
            engines = new SortedSet<Engine>();
            dataDeserializer = new DataDeserializer(this);
            initializeLabels();

            //Temporary Stuff
            combinator = new Combinator(drivers, teams, engines);

            foreach(Engine engine in engines)
            {
                foreach(Driver driver in engine.drivers)
                {
                    Console.WriteLine(driver.ToString());
                }
                Console.WriteLine("--------");
            }
        }

        public string getAvailableOptions()
        {
            combinator.combineAll();
            return combinator.createOptionsMessage();
        }

        private void initializeLabels()
        {
            int labelIndex = 0;

            foreach(Driver driver in drivers)
            {
                form.getDriverLabels()[labelIndex].Text = driver.ToString();
                labelIndex++;
            }

            labelIndex = 0;

            foreach (Team team in teams)
            {
                form.getTeamLabels()[labelIndex].Text = team.ToString();
                labelIndex++;
            }

            labelIndex = 0;

            foreach (Engine engine in engines)
            {
                form.getEngineLabels()[labelIndex].Text = engine.ToString();
                labelIndex++;
            }
        }
    }
}
