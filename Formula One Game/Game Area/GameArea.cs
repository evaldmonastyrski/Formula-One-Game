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

        public void CalculateCombinations(float budget, int combinationLimit)
        {
            availableDreamTeams.Clear();
            availableDreamTeams = combinator.getAvailableDreamTeams(budget, combinationLimit);
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
            float newPrice = Constants.PRICING_PRICE_COEFFICIENT * Drivers.ElementAt(driverIndex).Price + Constants.PRICING_POINTS_COEFFICIENT * points;
            newPrice = newPrice >= 0.5 ? newPrice : 0.5F;
            float priceChange = newPrice - Drivers.ElementAt(driverIndex).Price;
            priceChange = RoundFloat.round(priceChange);
            Drivers.ElementAt(driverIndex).Points = points;
            Drivers.ElementAt(driverIndex).PriceChange = priceChange;
            Form.DriverPointsLabels[driverIndex].Text = points != 0 ? points.ToString() : "";
            Form.DriverPriceChangeLabels[driverIndex].Text = priceChange.ToString();
            Form.ColorLabels(Form.DriverPriceChangeLabels[driverIndex], priceChange);

            for (int i = 0; i < Constants.NUMBER_OF_TEAMS; i++)
            {
                Team team = Teams.ElementAt(i);
                team.UpdatePoints();
                team.UpdatePriceChange();
                Form.TeamPointsLabels[i].Text = team.Points != 0 ? team.Points.ToString() : "";
                Form.TeamPriceChangeLabels[i].Text = team.PriceChange.ToString();
                Form.ColorLabels(Form.TeamPriceChangeLabels[i], team.PriceChange);
            }
            for (int i = 0; i < Constants.NUMBER_OF_ENGINES; i++)
            {
                Engine engine = Engines.ElementAt(i);
                engine.UpdatePoints();
                engine.UpdatePriceChange();
                Form.EnginePointsLabels[i].Text = engine.Points != 0 ? engine.Points.ToString() : "";
                Form.EnginePriceChangeLabels[i].Text = engine.PriceChange.ToString();
                Form.ColorLabels(Form.EnginePriceChangeLabels[i], engine.PriceChange);
            }
        }

        private void initializePriceChangeValues()
        {
            for (int i = 0; i < Constants.NUMBER_OF_DRIVERS; i++)
            {
                Driver driver = Drivers.ElementAt(i);
                float initialNewPrice = Constants.PRICING_PRICE_COEFFICIENT * driver.Price;
                initialNewPrice = initialNewPrice >= 0.5 ? initialNewPrice : 0.5F;
                float initialPriceChange = initialNewPrice - driver.Price;
                initialPriceChange = RoundFloat.round(initialPriceChange);
                Drivers.ElementAt(i).PriceChange = initialPriceChange;
                Form.DriverPriceChangeLabels[i].Text = initialPriceChange.ToString();
                Form.ColorLabels(Form.DriverPriceChangeLabels[i], initialPriceChange);
            }
            for (int i = 0; i < Constants.NUMBER_OF_TEAMS; i++)
            {
                Team team = Teams.ElementAt(i);
                team.UpdatePriceChange();
                Form.TeamPriceChangeLabels[i].Text = team.PriceChange.ToString();
                Form.ColorLabels(Form.TeamPriceChangeLabels[i], team.PriceChange);
            }
            for (int i = 0; i < Constants.NUMBER_OF_ENGINES; i++)
            {
                Engine engine = Engines.ElementAt(i);
                engine.UpdatePriceChange();
                Form.EnginePriceChangeLabels[i].Text = engine.PriceChange.ToString();
                Form.ColorLabels(Form.EnginePriceChangeLabels[i], engine.PriceChange);
            }
        }
        
        public string GetAvailableOptions(SortType sortType)
        {
            if (sortType == SortType.POINTS)
            {
                availableDreamTeams = availableDreamTeams.OrderByDescending(i => i.Points).ToList();
            }
            if (sortType == SortType.PRICE_CHANGE)
            {
                availableDreamTeams = availableDreamTeams.OrderByDescending(i => i.PriceChange).ToList();
            }
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