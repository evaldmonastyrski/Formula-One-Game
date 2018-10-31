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
            List<Engine> tempEngines = new List<Engine>();
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
                        if (tempEngines.Exists(x => x.Name.Equals(engine.Name)))
                        {
                            tempEngines.Find(x => x.Name.Contains(engine.Name)).AddDriver(driver);
                        }
                        else
                        {
                            tempEngines.Add(engine);
                            engine.AddDriver(driver);
                        }
                    }
                    foreach (Team teamInstance in tempTeams)
                    {
                        teamInstance.SetPrice();
                        GameArea.AddTeam(teamInstance);
                    }
                    foreach (Engine engineInstance in tempEngines)
                    {
                        engineInstance.SetPrice();
                        GameArea.AddEngine(engineInstance);
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
