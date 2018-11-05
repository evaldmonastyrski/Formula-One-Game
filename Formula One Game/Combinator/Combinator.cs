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
        private List<Driver> drivers;
        private List<Team> teams;
        private List<Engine> engines;

        public Combinator(SortedSet<Driver> drivers, SortedSet<Team> teams, SortedSet<Engine> engines)
        {
            DreamTeams = new SortedSet<DreamTeam>();
            this.drivers = drivers.ToList();
            this.teams = teams.ToList();
            this.engines = engines.ToList();
            CombineAll();
        }

        public SortedSet<DreamTeam> getAvailableDreamTeams(float budget)
        {
            SortedSet<DreamTeam> availableDreamTeams = copySet(DreamTeams);
            foreach (DreamTeam dreamTeam in DreamTeams)
            {
                dreamTeam.CalculatePoints();
                if (dreamTeam.Price > budget)
                {
                    availableDreamTeams.Remove(dreamTeam);
                }
            }
            return availableDreamTeams;
        }  

        private void CombineAll()
        {
            for (int i = 0; i < drivers.Count; i++)
            {
                for (int j = 0; j < drivers.Count; j++)
                {
                    if (j > i)
                    {
                        for (int k = 0; k < teams.Count; k++)
                        {
                            for (int l = 0; l < engines.Count; l++)
                            {
                                DreamTeams.Add(new DreamTeam(drivers[i], drivers[j], teams[k], engines[l]));    
                            }
                        }
                    }
                }
            }
        }

        private SortedSet<DreamTeam> copySet(SortedSet<DreamTeam> copyFrom)
        {
            SortedSet<DreamTeam> copyTo = new SortedSet<DreamTeam>();
            foreach (DreamTeam dreamTeamMember in copyFrom)
            {
                copyTo.Add(dreamTeamMember);
            }
            return copyTo;
        }

    }
}
