using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class Combinator
    {
        public SortedSet<DreamTeam> DreamTeams { get; }
        private List<Driver> Drivers;
        private List<Team> Teams;
        private List<Engine> Engines;
        private float budget;

        public Combinator(SortedSet<Driver> drivers, SortedSet<Team> teams, SortedSet<Engine> engines, float budget)
        {
            DreamTeams = new SortedSet<DreamTeam>();
            Drivers = drivers.ToList<Driver>();
            Teams = teams.ToList<Team>();
            Engines = engines.ToList<Engine>();
            this.budget = budget;
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
        }
    }
}
