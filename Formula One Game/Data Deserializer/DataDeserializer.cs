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

        public DataDeserializer(GameArea gameArea)
        {
            GameArea = gameArea;
            InitializeDreamTeamComponents();
        }

        public void InitializeDreamTeamComponents()
        {
            try
            {
                using (StreamReader myStreamReader = new StreamReader("..\\..\\MarketData.txt"))
                {
                    string firstLine = myStreamReader.ReadLine();
                    string[] firstLineWords = firstLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in firstLineWords)
                    {
                        GameArea.AddGPStage(word);
                    }
                    while (!myStreamReader.EndOfStream)
                    {
                        string line = myStreamReader.ReadLine();
                        string[] lineWords = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Driver driver = new Driver(lineWords[0], lineWords[1], float.Parse(lineWords[4]));
                        GameArea.AddDriver(driver);
                        Team team = new Team(lineWords[2]);

                        if(!GameArea.Teams.Contains(team))
                        {
                            GameArea.AddTeam(team);
                            team.AddDriver(driver);
                        }
                        else
                        {
                            foreach(Team teamInstance in GameArea.Teams)
                            {
                                if(teamInstance.ToString().Equals(team.ToString()))
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
                }
            } 
            catch (FileNotFoundException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
            }
            
        }
    }
}
