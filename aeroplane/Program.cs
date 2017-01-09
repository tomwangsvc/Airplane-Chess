using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aeroplane
{
    class Program
    {
        static int[] Maps = new int[100];
        static int[] PlayerPos = new int[2];// array used to store player location
        static string[] PlayerNames = new string[2];//store players'name
        static bool[] Flags = new bool[2];//mark two players 
        static void Main(string[] args)
        {

            GameShow();
            #region input players' names
            Console.WriteLine("please input Player A's name");
            PlayerNames[0] = Console.ReadLine();
            while (PlayerNames[0] == "")
            {
                Console.WriteLine("Player A can not be null, please input again");
                PlayerNames[0] = Console.ReadLine();
            }
            Console.WriteLine("please input Player B's name");
            PlayerNames[1] = Console.ReadLine();
            while (PlayerNames[1] == ""||PlayerNames[1]==PlayerNames[0])
            {
                if (PlayerNames[1] == "")
                {
                    Console.WriteLine("Player B can not be null, please input again");
                    PlayerNames[1] = Console.ReadLine();
                }
                else {
                    Console.WriteLine("Players'names cant be the same");
                    PlayerNames[1] = Console.ReadLine();
                }
            }
            #endregion
            Console.Clear();
            GameShow();
            Console.WriteLine("{0} is displayed by A", PlayerNames[0]);
            Console.WriteLine("{0} is displayed by b", PlayerNames[1]);
            
            InitialMap();
            DrawMap();
            while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
            {
                if (Flags[0] == false)
                { 
                PlayGame(0);
                }
                else
                {
                Flags[0]=false;
                }
                if (Flags[1] == false)
                {
                    PlayGame(1);
                }
                else {
                    Flags[1] = false;
                }
                if (PlayerPos[1] >= 99)
                {
                    Console.WriteLine("Player{0}win the game", PlayerNames[1]);
                    break;
                }
                if (PlayerPos[0] >= 99)
                {
                    Console.WriteLine("Player{0}win the game", PlayerNames[0]);
                    break;
                }


            }
            Console.ReadKey();
        }
        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****Aeroplane*************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("******Madeby Sheng Wang****");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        public static void InitialMap()
        {
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 };
            for (int i = 0; i < luckyturn.Length; i++)
            {
                int index = luckyturn[i];
                Maps[index] = 1;
            }
            int[] landmine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            for (int i = 0; i < landmine.Length; i++)
            {
                int index = landmine[i];
                Maps[index] = 2;
            }
            int[] pause = { 9, 27, 60, 93 };
            for (int i = 0; i < pause.Length; i++)
            {
                int index = pause[i];
                Maps[index] = 3;
            }
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                int index = timeTunnel[i];
                Maps[index] = 4;
            }
        }
        public static void DrawMap()
        {
            #region firstrow
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion
            Console.WriteLine();
            #region firstcolumn
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }

                Console.Write(DrawStringMap(i));
                Console.WriteLine();
            }
            #endregion
            #region secondrow
            for (int i = 64; i >= 35; i--) {
                Console.Write(DrawStringMap(i));
            }
            #endregion
            Console.WriteLine();
            #region secondcolumn
            for (int i = 65; i <= 69; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion

            #region thirdrow
            for (int i = 70; i < 99; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion
            Console.WriteLine();
        }
        public static string DrawStringMap(int i)
      
        {
            string str = "";
            //player A is located in the same spot as player B and they both are in the map, draw <>
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[1] == i)
            {
                str="<>";
            }
            else if (PlayerPos[0] == i)
            {
                str=" A";
            }
            else if (PlayerPos[1] == i)
            {
                str=" B";
            }
            else
            {
                switch (Maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                       str=" □";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str=" ◎";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str=" ☆";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str=" ▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        str=" 卐";
                        break;
                }
            }
            return str;
        }
    
        public static void ChangePos() {
            if (PlayerPos[0] < 0)
            {
                PlayerPos[0] = 0;
            }
            if (PlayerPos[0] >=99)
            {
                PlayerPos[0] = 99;
            }
            if (PlayerPos[1] < 0)
            {
                PlayerPos[1] = 0;
            }
            if (PlayerPos[1] >=99)
            {
                PlayerPos[1] = 99;
            }
        }
        public static void PlayGame(int playerNumber)
        {
            Random r = new Random();
            int rNumber = r.Next(1, 7);
            Console.WriteLine("{0}input any key to roll the dice", PlayerNames[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}can move{1}", PlayerNames[playerNumber], rNumber);
            PlayerPos[playerNumber] += rNumber;
            Console.ReadKey(true);
            Console.WriteLine("{0}input any key to move", PlayerNames[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0} 's action is over", PlayerNames[playerNumber]);
            Console.ReadKey(true);
            if (PlayerPos[playerNumber] == PlayerPos[1 - playerNumber])
            {
                Console.WriteLine("Player {0} step on player {1} move back 6 steps", PlayerNames[playerNumber], PlayerNames[1 - playerNumber]);
                PlayerPos[1 - playerNumber] -= 6;
                Console.ReadKey(true);
            }
            else {
                switch (Maps[PlayerPos[playerNumber]])
                {
                    case 0: Console.WriteLine("Player {0} move normally and safely", PlayerNames[playerNumber]);
                        Console.ReadKey(true);
                        break;
                    case 1: Console.WriteLine("Player{0}step on fortunate weel, please choose 1: switch places 2: destroy the opponent");
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("Player{0} want to switch place", PlayerNames[playerNumber]);
                                int temp = PlayerPos[playerNumber];
                                PlayerPos[playerNumber] = PlayerPos[1 - playerNumber];
                                PlayerPos[1 - playerNumber] = temp;
                                Console.WriteLine("switch successfully!! Keep going");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("Player{0}choose to destroy the opponent, player {1} move six steps back", PlayerNames[playerNumber], PlayerNames[1 - playerNumber]);
                                PlayerPos[1 - playerNumber] -= 6;
                                Console.WriteLine("Player{0} move 6 steps back", PlayerPos[1 - playerNumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else {
                                Console.WriteLine("Please choose 1 or 2   1:swap places 2:destroy your opponent");
                                input = Console.ReadLine();
                            }
                        }
                        break;
                    case 2: Console.WriteLine("Player{0}step on the trap, move six steps back", PlayerNames[playerNumber]);
                        PlayerPos[playerNumber] -= 6;
                        Console.ReadKey(true);
                        break;
                    case 3: Console.WriteLine("Player{0}step on the pause", PlayerNames[playerNumber]);
                        Flags[playerNumber] = true;
                        Console.ReadKey(true);
                        break;
                    case 4: Console.WriteLine("Player{0}step on the time channel, move forward 10 steps", PlayerNames[playerNumber]);
                        PlayerPos[playerNumber] += 10;
                        Console.ReadKey(true);
                        break;
                }
            }
            ChangePos();
            Console.Clear();
            DrawMap();
        }
    }
}