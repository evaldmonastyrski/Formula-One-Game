using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_One_Game
{
    public static class Constants
    {
        public const int NUMBER_OF_DRIVERS = 20;
        public const int NUMBER_OF_TEAMS = 10;
        public const int NUMBER_OF_ENGINES = 4;
        public const float TEAM_PRICE_RATIO = 0.8F;
        public const float ENGINE_PRICE_RATIO = 0.2F;
        public static readonly Dictionary<int, float> qualificationPositionToPointsMap = new Dictionary<int, float>()
        {
            {1, 10},
            {2, 8},
            {3, 6},
            {4, 5},
            {5, 4},
            {6, 3},
            {7, 2},
            {8, 1},
            {9, 0},
            {10, 0},
            {11, 0},
            {12, 0},
            {13, 0},
            {14, 0},
            {15, 0},
            {16, 0},
            {17, 0},
            {18, 0},
            {19, 0},
            {20, 0},
            {0, 0 }
        };
        public static readonly Dictionary<int, float> racePositionToPointsMap = new Dictionary<int, float>()
        {
            {1, 25},
            {2, 18},
            {3, 15},
            {4, 12},
            {5, 10},
            {6, 8},
            {7, 6},
            {8, 5},
            {9, 4},
            {10, 3},
            {11, 2},
            {12, 1},
            {13, 0},
            {14, 0},
            {15, 0},
            {16, 0},
            {17, 0},
            {18, 0},
            {19, 0},
            {20, 0},
            {0, 0 }
        };
    }
}
