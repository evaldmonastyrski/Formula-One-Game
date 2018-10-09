using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Combinator
    {
        private SortedSet<DreamTeam> DreamTeam;
        private List<Driver> Drivers;
        private List<Team> Teams;
        private List<Engine> Engines;

        public Combinator(SortedSet<Driver> drivers, SortedSet<Team> teams, SortedSet<Engine> engines)
        {
            DreamTeam = new SortedSet<DreamTeam>();
            Drivers = drivers.ToList<Driver>();
            Teams = teams.ToList<Team>();
            Engines = engines.ToList<Engine>();
        }

        public void CombineAll()
        {
            for (int i = 0; i < Drivers.Count; i++)
            {
                for (int j = 0; j < Drivers.Count; j++)
                {
                    if (j > i)
                    {
                        for (int k = 0; k < Teams.Count; k++)
                        {
                            for (int l = 0; l < Engines.Count; l++)
                            {
                                DreamTeam.Add(new DreamTeam(Drivers[i], Drivers[j], Teams[k], Engines[l]));
                            }
                        }
                    }
                }
            }
        }

        public string CreateOptionsMessage()
        {
            int lineNumber = 1;
            string message = "";

            foreach (DreamTeam dreamTeamMember in DreamTeam)
            {
                message += String.Format(
                    "#{0, -6} {1, -14} {2, -13} {3, -13} {4, -13} \r\n",
                    lineNumber,
                    dreamTeamMember.GetDriver1Surname(),
                    dreamTeamMember.GetDriver2Surname(),
                    dreamTeamMember.GetTeamName().Replace("_", " "),
                    dreamTeamMember.GetEngineName());

                lineNumber++;
            }
            return message;
        }
    }
}
