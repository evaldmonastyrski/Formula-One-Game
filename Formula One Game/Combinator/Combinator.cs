using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Combinator
    {
        private SortedSet<DreamTeam> dreamTeam = new SortedSet<DreamTeam>();
        private List<Driver> drivers;
        private List<Team> teams;
        private List<Engine> engines;

        public Combinator(SortedSet<Driver> drivers, SortedSet<Team> teams, SortedSet<Engine> engines)
        {
            this.drivers = drivers.ToList<Driver>();
            this.teams = teams.ToList<Team>();
            this.engines = engines.ToList<Engine>();
        }

        public SortedSet<DreamTeam> getCombinations()
        {
            return dreamTeam;
        }

        public void combineAll()
        {
            for (int i = 0; i < drivers.Count; i++)
            {
                for (int j = 0; j < drivers.Count; j++)
                {
                    if (j > i)
                    {
                        for (int k = 0; k < teams.Count; k++)
                        {
                          //  for (int l = 0; l < engines.Count; l++)
                          //  {
                                dreamTeam.Add(new DreamTeam(drivers[i], drivers[j], teams[k]));
                         //   }
                        }
                    }
                }
            }
        }

        public string createOptionsMessage()
        {
            int lineNumber = 1;
            string message = "";

            foreach (DreamTeam dreamTeamMember in dreamTeam)
            {
                message += String.Format(
                    "#{0, -6} {1, -14} {2, -13} {3, -13} \r\n",
                    lineNumber,
                    dreamTeamMember.getDriver1Name(),
                    dreamTeamMember.getDriver2Name(),
                    dreamTeamMember.getTeamName());
                lineNumber++;
            }
            return message;
        }
    }
}
