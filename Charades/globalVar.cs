using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Charades
{
    public class globalVar
    {
        public static string Player1;
        public static string Player2;
        public static string Player3;
        public static string Player4;
        public static string Player5;
        public static string Player6;
        public static string Player7;

        public static int NumOfPlayers;
        public static int NumOfPlayersThatDrew;
        public static int Player1Score;
        public static int Player2Score;
        public static int Player3Score;
        public static int Player4Score;
        public static int Player5Score;
        public static int Player6Score;
        public static int Player7Score;

        public static bool isAssigned;
        public static bool isDrawingDone;

        public static List<string> playersList = new List<string>();
        public static List<string> playersListOrdered = new List<string>();
        public static List<string> playersListBackup = new List<string>();

        public static List<string> Words = new List<string> 
        {
            "Sun",
            "Knife",
            "Half",
            "Cardboard",
            "Baby-sitter",
            "Drip",
            "Shampoo",
            "Point",
            "Time machine",
            "Yardstick",
            "Think",
            "Lace", 
            "Darts",
            "World", 
            "Avocado", 
            "Bleach",
            "Shower curtain",
            "Extension cord",
            "Dent",
            "Birthday", 
            "Lap",
            "Sandbox",
            "Bruise", 
            "Quicksand",
            "Fog",
            "Gasoline", 
            "Pocket", 
            "Honk",
            "Sponge", 
            "Rim", 
            "Bride",
            "Wig", 
            "Zipper", 
            "Wag",
            "Letter opener", 
            "Fiddle", 
            "Pilot",
            "Brand", 
            "Pail",
            "Baguette", 
            "Rib", 
            "Mascot",
            "Fireman pole", 
            "Zoo", 
            "Sushi",
            "Fizz", 
            "Ceiling fan", 
            "Bald",
            "Banister", 
            "Punk", 
            "Post office",
            "Season",
            "Internet", 
            "Chess",
            "Puppet", 
            "Chime", 
            "Ivy",
            "Full", 
            "Koala", 
            "Dentist",
        };

        public static List<string> WordsBackup = new List<string>
        {
            "Sun",
            "Knife",
            "Half",
            "Cardboard",
            "Baby-sitter",
            "Drip",
            "Shampoo",
            "Point",
            "Time machine",
            "Yardstick",
            "Think",
            "Lace", 
            "Darts",
            "World", 
            "Avocado", 
            "Bleach",
            "Shower curtain",
            "Extension cord",
            "Dent",
            "Birthday", 
            "Lap",
            "Sandbox",
            "Bruise", 
            "Quicksand",
            "Fog",
            "Gasoline", 
            "Pocket", 
            "Honk",
            "Sponge", 
            "Rim", 
            "Bride",
            "Wig", 
            "Zipper", 
            "Wag",
            "Letter opener", 
            "Fiddle", 
            "Pilot",
            "Brand", 
            "Pail",
            "Baguette", 
            "Rib", 
            "Mascot",
            "Fireman pole", 
            "Zoo", 
            "Sushi",
            "Fizz", 
            "Ceiling fan", 
            "Bald",
            "Banister", 
            "Punk", 
            "Post office",
            "Season",
            "Internet", 
            "Chess",
            "Puppet", 
            "Chime", 
            "Ivy",
            "Full", 
            "Koala", 
            "Dentist",
        };
    }
}
