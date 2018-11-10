using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    class RoundFloat
    {
        public static float round(float number)
        {
            return (float)(Math.Round((double) number, 1));
        }

        public static float roundTo2(float number)
        {
            return (float)(Math.Round((double) number, 2));
        }
    }
}
