using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Combinator
    {
        public static SortedSet<DreamTeam> CombineAll(SortedSet<Driver> drivers, SortedSet<Team> teams, SortedSet<Engine> engines, float budget)
        {
            List<Driver> Drivers = drivers.ToList<Driver>();
            List<Team> Teams = teams.ToList<Team>();
            List<Engine> Engines = engines.ToList<Engine>();
            SortedSet<DreamTeam> DreamTeams = new SortedSet<DreamTeam>();

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
                                DreamTeam dreamTeam = new DreamTeam(Drivers[i], Drivers[j], Teams[k], Engines[l], budget);
                                if (dreamTeam.Price < budget)
                                {
                                    DreamTeams.Add(dreamTeam);
                                }
                            }
                        }
                    }
                }
            }
            return DreamTeams;
        }
    }
}
