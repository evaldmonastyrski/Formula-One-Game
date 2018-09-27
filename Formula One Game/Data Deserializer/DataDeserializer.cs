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
            Console.WriteLine("Deserializer is starting...");
            this.gameArea = gameArea;
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
                        gameArea.addDriver(new Driver(lineWords[0], lineWords[1]));
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
