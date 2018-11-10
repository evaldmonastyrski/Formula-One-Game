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
        private List<DreamTeam> availableDreamTeams;

        public GameArea(Form1 form)
        {
            Form = form;
            dataDeserializer = new DataDeserializer(this);
            GPStages = new List<string>();
            InitializeStageDependentGameAreaComponents(INITIAL_GP_STAGE_INDEX);
            initializeGPStages();
        }

        public void InitializeStageDependentGameAreaComponents(int gpStageIndex)
        {
            Drivers = new SortedSet<Driver>();
            Teams = new SortedSet<Team>();
            Engines = new SortedSet<Engine>();
            availableDreamTeams = new List<DreamTeam>();
            dataDeserializer.InitializeDreamTeamComponents(gpStageIndex);
            combinator = new Combinator(Drivers, Teams, Engines);
            initializePriceChangeValues();
            initializeLabels();
        }

        public void CalculateCombinations(float budget)
        {
            availableDreamTeams.Clear();
            availableDreamTeams = combinator.getAvailableDreamTeams(budget);
            availableDreamTeams = availableDreamTeams.OrderBy(i => i.Points).ToList();
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

        public void UpdateDreamTeamComponents(int driverIndex, int qPosition, int rPosition)
        {
            float points = Constants.qualificationPositionToPointsMap[qPosition] + Constants.racePositionToPointsMap[rPosition];
            float priceChange = Constants.PRICING_PRICE_COEFFICIENT * Drivers.ElementAt(driverIndex).Price + Constants.PRICING_POINTS_COEFFICIENT * points - Drivers.ElementAt(driverIndex).Price;
            Drivers.ElementAt(driverIndex).Points = points;
            Drivers.ElementAt(driverIndex).PriceChange = priceChange;
            Form.DriverPointsLabels[driverIndex].Text = points != 0 ? points.ToString() : "";
            Form.DriverPriceChangeLabels[driverIndex].Text = RoundFloat.round(priceChange).ToString();
            Form.ColorLabels(Form.DriverPriceChangeLabels[driverIndex], priceChange);

            for (int i = 0; i < Constants.NUMBER_OF_TEAMS; i++)
            {
                Team team = Teams.ElementAt(i);
                team.UpdatePoints();
                team.UpdatePriceChange();
                Form.TeamPointsLabels[i].Text = team.Points != 0 ? team.Points.ToString() : "";
                Form.TeamPriceChangeLabels[i].Text = RoundFloat.round(team.PriceChange).ToString();
                Form.ColorLabels(Form.TeamPriceChangeLabels[i], team.PriceChange);
            }
            for (int i = 0; i < Constants.NUMBER_OF_ENGINES; i++)
            {
                Engine engine = Engines.ElementAt(i);
                engine.UpdatePoints();
                engine.UpdatePriceChange();
                Form.EnginePointsLabels[i].Text = engine.Points != 0 ? engine.Points.ToString() : "";
                Form.EnginePriceChangeLabels[i].Text = RoundFloat.round(engine.PriceChange).ToString();
                Form.ColorLabels(Form.EnginePriceChangeLabels[i], engine.PriceChange);
            }
        }

        private void initializePriceChangeValues()
        {
            for (int i = 0; i < Constants.NUMBER_OF_DRIVERS; i++)
            {
                Driver driver = Drivers.ElementAt(i);
                float initialPriceChange = (Constants.PRICING_PRICE_COEFFICIENT - 1) * driver.Price;
                Drivers.ElementAt(i).PriceChange = initialPriceChange;
                Form.DriverPriceChangeLabels[i].Text = RoundFloat.round(initialPriceChange).ToString();
                Form.ColorLabels(Form.DriverPriceChangeLabels[i], initialPriceChange);
            }
            for (int i = 0; i < Constants.NUMBER_OF_TEAMS; i++)
            {
                Team team = Teams.ElementAt(i);
                float initialPriceChange = (Constants.PRICING_PRICE_COEFFICIENT - 1) * team.Price;
                Teams.ElementAt(i).PriceChange = initialPriceChange;
                Form.TeamPriceChangeLabels[i].Text = RoundFloat.round(initialPriceChange).ToString();
                Form.ColorLabels(Form.TeamPriceChangeLabels[i], initialPriceChange);
            }
            for (int i = 0; i < Constants.NUMBER_OF_ENGINES; i++)
            {
                Engine engine = Engines.ElementAt(i);
                float initialPriceChange = (Constants.PRICING_PRICE_COEFFICIENT - 1) * engine.Price;
                Engines.ElementAt(i).PriceChange = initialPriceChange;
                Form.EnginePriceChangeLabels[i].Text = RoundFloat.round(initialPriceChange).ToString();
                Form.ColorLabels(Form.EnginePriceChangeLabels[i], initialPriceChange);
            }
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