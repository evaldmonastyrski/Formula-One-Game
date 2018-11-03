using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class GameArea
    {
        private const int INITIAL_GP_STAGE_INDEX = 0;

        public SortedSet<Driver> Drivers { get; private set; }
        public SortedSet<Team> Teams { get; private set; }
        public SortedSet<Engine> Engines { get; private set; }
        private List<String> GPStages { get; }
        private Form1 Form;
        private DataDeserializer dataDeserializer;
        private Combinator combinator;
        private SortedSet<DreamTeam> availableDreamTeams;

        public GameArea(Form1 form)
        {
            Form = form;
            dataDeserializer = new DataDeserializer(this);
            GPStages = new List<string>();
            initializeStageDependentGameAreaComponents(INITIAL_GP_STAGE_INDEX);
            initializeGPStages();
        }

        public void initializeStageDependentGameAreaComponents(int gpStageIndex)
        {
            Drivers = new SortedSet<Driver>();
            Teams = new SortedSet<Team>();
            Engines = new SortedSet<Engine>();
            availableDreamTeams = new SortedSet<DreamTeam>();
            dataDeserializer.InitializeDreamTeamComponents(gpStageIndex);
            combinator = new Combinator(Drivers, Teams, Engines);
            initializeLabels();
        }

        public void CalculateCombinations(float budget)
        {
            availableDreamTeams.Clear();
            availableDreamTeams = combinator.getAvailableDreamTeams(budget);
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
            GPStages.AddRange(gpStages);
        }

        public void UpdatePoints(int driverIndex, int qPosition, int rPosition)
        {
            float points = Constants.qualificationPositionToPointsMap[qPosition] + Constants.racePositionToPointsMap[rPosition];
            Drivers.ElementAt(driverIndex).Points = points;
            Form.DriverPointsLabels[driverIndex].Text = points != 0 ? points.ToString() : "";
        }
        
        public string GetAvailableOptions()
        {
            return AvailableOptions.CreateOptionsMessage(availableDreamTeams);
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