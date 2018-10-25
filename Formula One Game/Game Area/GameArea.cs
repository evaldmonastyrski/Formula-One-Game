using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class GameArea
    {
        private const float INITIAL_BUDGET = 30.0F;

        public SortedSet<Driver> Drivers { get; }
        public SortedSet<Team> Teams { get; }
        public SortedSet<Engine> Engines { get; }
        private List<String> GPStages { get; }
        private Form1 Form;
        private DataDeserializer dataDeserializer;
        private Combinator combinator;
        private Simulator simulator;
        private AvailableOptions availableOptions;

        public GameArea(Form1 form, int gpStageIndex)
        {
            Form = form;
            Drivers = new SortedSet<Driver>();
            Teams = new SortedSet<Team>();
            Engines = new SortedSet<Engine>();
            GPStages = new List<string>();
            dataDeserializer = new DataDeserializer(this, gpStageIndex);
            combinator = new Combinator(Drivers, Teams, Engines, INITIAL_BUDGET);
            simulator = new Simulator();
            availableOptions = new AvailableOptions(combinator.DreamTeams);
            initializeGPStages();
            initializeLabels();
        }

        public void RecalculateCombinations(float budget)
        {
            combinator = new Combinator(Drivers, Teams, Engines, budget);
            availableOptions = new AvailableOptions(combinator.DreamTeams);
        }

        public void AddDriver(Driver driver)
        {
            Drivers.Add(driver);
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }

        public void AddEngine(Engine engine)
        {
            Engines.Add(engine);
        }

        public void AddGPStages(string[] gpStages)
        {
            GPStages.Clear();
            GPStages.AddRange(gpStages);
        }
        
        public string GetAvailableOptions()
        {
            combinator.CombineAll();
            return availableOptions.CreateOptionsMessage();
        }

        private void initializeGPStages()
        {
            Form.SetGPCombo(GPStages);
        }

        private void initializeLabels()
        {
            int labelIndex = 0;
            foreach(Driver driver in Drivers)
            {
                Form.DriverLabels[labelIndex].Text = driver.ToString();
                labelIndex++;
            }

            labelIndex = 0;
            foreach (Team team in Teams)
            {
                Form.TeamLabels[labelIndex].Text = team.ToString();
                labelIndex++;
            }

            labelIndex = 0;
            foreach (Engine engine in Engines)
            {
                Form.EngineLabels[labelIndex].Text = engine.ToString();
                labelIndex++;
            }
        }
    }
}