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
        }

        public void InitializeDreamTeamComponents(int gpStageIndex)
        {
            List<Team> tempTeams = new List<Team>();
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
                        if (tempTeams.Exists(x => x.Name.Equals(team.Name)))
                        {
                            tempTeams.Find(x => x.Name.Contains(team.Name)).AddDriver(driver);
                        }
                        else
                        {
                            tempTeams.Add(team);
                            team.AddDriver(driver);
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
