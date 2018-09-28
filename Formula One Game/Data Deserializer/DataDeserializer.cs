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
        private GameArea gameArea;

        public DataDeserializer(GameArea gameArea)
        {
            this.gameArea = gameArea;
            initializeDreamTeamComponents();
        }

        public void initializeDreamTeamComponents()
        {
            try
            {
                using (StreamReader myStreamReader = new StreamReader("..\\..\\MarketData.txt"))
                {
                    while (!myStreamReader.EndOfStream)
                    {
                        String line = myStreamReader.ReadLine();
                        String[] lineWords = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Driver driver = new Driver(lineWords[0], lineWords[1]);
                        gameArea.addDriver(driver);
                        Team team = new Team(lineWords[2]);
                        if(!gameArea.getTeams().Contains(team))
                        {
                            gameArea.addTeam(team);
                            team.addDriver(driver);
                        }
                        else
                        {
                            foreach(Team teamInstance in gameArea.getTeams())
                            {
                                if(teamInstance.ToString().Equals(team.ToString()))
                                {
                                    teamInstance.addDriver(driver);
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
