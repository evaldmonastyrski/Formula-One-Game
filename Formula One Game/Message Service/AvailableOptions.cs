using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class AvailableOptions
    {
        public static string CreateOptionsMessage(SortedSet<DreamTeam> dreamTeams)
        {
            int lineNumber = 1;
            string message = "";

            foreach (DreamTeam dreamTeamMember in dreamTeams)
            {
                message += String.Format(
                    "#{0, -6} {1, -14} {2, -13} {3, -13} {4, -13} {5, -13} {6, -13} \r\n",
                    lineNumber,
                    dreamTeamMember.GetDriver1Surname(),
                    dreamTeamMember.GetDriver2Surname(),
                    dreamTeamMember.GetTeamName().Replace("_", " "),
                    dreamTeamMember.GetEngineName(),
                    dreamTeamMember.Price,
                    dreamTeamMember.Points);

                lineNumber++;
            }
            return message;
        }
    }
}
