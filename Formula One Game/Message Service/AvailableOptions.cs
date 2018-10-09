using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class AvailableOptions
    {
        private SortedSet<DreamTeam> DreamTeams;

        public AvailableOptions(SortedSet<DreamTeam> dreamTeams)
        {
            DreamTeams = dreamTeams;
        }

        public string CreateOptionsMessage()
        {
            int lineNumber = 1;
            string message = "";

            foreach (DreamTeam dreamTeamMember in DreamTeams)
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
