﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class GameArea
    {
        private const float INITIAL_BUDGET = 30.0F;
        private const int INITIAL_GP_STAGE_INDEX = 0;

        public SortedSet<Driver> Drivers { get; private set; }
        public SortedSet<Team> Teams { get; private set; }
        public SortedSet<Engine> Engines { get; private set; }
        private List<String> GPStages { get; }
        private Form1 Form;
        private DataDeserializer dataDeserializer;
        private AvailableOptions availableOptions;

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
            dataDeserializer.InitializeDreamTeamComponents(gpStageIndex);
            availableOptions = new AvailableOptions(Combinator.CombineAll(Drivers, Teams, Engines, INITIAL_BUDGET));
            initializeLabels();
        }

        public void RecalculateCombinations(float budget)
        {
            availableOptions = new AvailableOptions(Combinator.CombineAll(Drivers, Teams, Engines, INITIAL_BUDGET));
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
        
        public string GetAvailableOptions()
        {
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