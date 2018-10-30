using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Formula_One_Game
{
    class DataDeserializer
    {
        private GameArea GameArea;
        private SortedSet<Team> tempTeams;

        public DataDeserializer(GameArea gameArea)
        {
            GameArea = gameArea;
            tempTeams = new SortedSet<Team>();
        }

        public void InitializeDreamTeamComponents(int gpStageIndex)
        {
            tempTeams.Clear();
            try
            {
                using (StreamReader myStreamReader = new StreamReader("..\\..\\MarketData.txt"))
                {
                    string firstLine = myStreamReader.ReadLine();
                    string[] firstLineWords = firstLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    GameArea.AddGPStages(firstLineWords);
                    while (!myStreamReader.EndOfStream)
                    {
                        string line = myStreamReader.ReadLine();
                        string[] lineWords = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Driver driver = new Driver(lineWords[0], lineWords[1], float.Parse(lineWords[gpStageIndex + 4]));
                        GameArea.AddDriver(driver);
                        Team team = new Team(lineWords[2]);
                        if (!tempTeams.Contains(team))
                        {
                            tempTeams.Add(team);
                            team.AddDriver(driver);
                        }
                        else
                        {
                            foreach (Team teamInstance in tempTeams)
                            {
                                if (teamInstance.ToString().Equals(team.ToString()))
                                {
                                    teamInstance.AddDriver(driver);
                                }
                            }
                        }
                        Engine engine = new Engine(lineWords[3]);
                        if(!GameArea.Engines.Contains(engine))
                        {
                            GameArea.AddEngine(engine);
                            engine.AddDriver(driver);
                        }
                        else
                        {
                            foreach(Engine engineInstance in GameArea.Engines)
                            {
                                if(engineInstance.ToString().Equals(engine.ToString()))
                                {
                                    engineInstance.AddDriver(driver);
                                }
                            }
                        }
                    }
                    foreach (Team teamInstance in tempTeams)
                    {
                        teamInstance.SetPrice();
                        GameArea.AddTeam(teamInstance);
                    }
                }
            } 
            catch (FileNotFoundException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
            }
            
        }
    }
}
