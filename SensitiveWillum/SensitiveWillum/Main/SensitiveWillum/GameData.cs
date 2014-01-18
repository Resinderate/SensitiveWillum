using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SensitiveWillum
{
    class GameData
    {
        public static int[,] levelOne;

        public static bool DEBUG_SHOW_BOUNDING_RECTANGLES = false;

        #region MENU STRINGS;
        //all the strings shown to the user through the menu
        public static String GAME_TITLE = "SensitiveWillum";
        public static String MENU_CONTINUE = "continue";
        public static String MENU_RESTART = "restart";
        public static String MENU_QUIT = "quit";

        public static Color MENU_INACTIVE_COLOR = Color.White;
        public static Color MENU_ACTIVE_COLOR = new Color(0, 198, 255);

        #endregion;

        #region LEVEL VARIABLES
        public static int LEVEL_WIDTH = 770;
        public static int LEVEL_HEIGHT = 2400;
        #endregion

        public static void setupLevelData()
        {
            //initialize 2D array in constructor as you will only have one of them, otherwise
            //should make a seperate method.
            levelOne = new int[35, 11] 
            {
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0, 41,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  5,  0,  0},
            {0,  0,  0,  0, 99,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0, 98, 20,  0,  0,  0,  0,  0},
            {0,  0,  0,  3,  2,  4,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0, 12,  0, 30,  0,  0,  0,  0,  0,  0,  0},
            {2,  2,  2,  2,  2,  4,  0,  0,  0,  0, 40},
            {0,  0,  0,  0,  0,  0,  3,  4,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  5,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0, 30,  0,  0,  0},
            {0,  0,  3,  4,  0,  0,  3,  2,  4,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0, 13, 12},
           {30,  0,  0,  0,  0,  0,  0,  0,  0,  3,  2},
            {2,  4,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0,  0, 11, 10,  0,  0,  0,  0,  0,  0,  0},
           {41,  0,  3,  4,  0,  0,  0,  0,  0,  0,  0},
            {3,  4,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  3,  4,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0, 10, 11,  0,  0,  0,  0},
            {0,  0,  0,  3,  2,  2,  2,  4,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0, 41,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {0, 12,  0,  0,  0,  0,  0,  0,  0,  0,  0},
            {2,  2,  2,  4,  0,  0,  0,  0,  0,  0,  0},
            {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
           {30,  0,  0,  0,  0,  0,  0, 13,  0, 12, 21},
            {2,  2,  2,  6,  6,  2,  2,  2,  2,  2,  2},
            {1,  1,  1,  8,  8,  1,  1,  1,  1,  1,  1},
            };

        }
    }
}
