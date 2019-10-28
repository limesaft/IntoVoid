using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class FightState
    {
        private int currentLevel;
        private bool ifFightOn = true;
        private string[] EnemyScreen;
        public List<string> EnemyScreenList { get => _enemyScreenList; set => _enemyScreenList = value; }
        public int WidthActionBar { get => widthActionBar; set => widthActionBar = value; }

        private char[] PrintPlayerScreen;
        private string[] OrginalPlayerScreen;

        private List<string> _enemyScreenList = new List<string>();

        private int heightOnEnemyScreen = 0;
        private int widthOnEnemyScreen = 0;
       // private int totalLengthES = 0;

        private int widthActionBar = 0;
        private int heightActionBar = 0;
        private int totalLengthPlayerAB = 0;

        // position for actionbar,
        private int posHp = 113;
        private int posAttack = 135;
        private int posXpLeft = 189;
        private int posCrystals = 268;

        public FightState() { }

        public void FightOnEvent(Player player, int level)
        {
            LoadEnemy(level);
            RenderEnemyScreen();
            LoadPlayerActionBar();

            while (ifFightOn)
            {
                RenderPlayerActionBar(player);

                //if enenyms dead fight = false;
                ifFightOn = false;
                Console.ReadKey();
            }
            // enemy worth in XP;
            player.CheckLevelUp(1);
        }

        private void LoadEnemy(int level)
        {
            CleanBeforeFight(level);
            LoadEnemyScreen();
        }

        private void LoadEnemyScreen()
        {
            EnemyScreen = System.IO.File.ReadAllLines(@"..\..\EnemyScreens\EnemyLow.txt");

            foreach (string item in EnemyScreen)
            {
                foreach (char character in item)
                {
                    EnemyScreenList.Add(character.ToString());
                    //    totalLengthES++;
                }

                widthOnEnemyScreen = item.Count();
                heightOnEnemyScreen++;
            }
        }

        private void CleanBeforeFight(int level)
        {
            Console.Clear();
            ifFightOn = true;
            currentLevel = level;
            EnemyScreenList.Clear();
            heightOnEnemyScreen = 0;
            totalLengthPlayerAB = 0;
        }

        private void RenderEnemyScreen()
        {
            for (int i = 0; i < heightOnEnemyScreen * widthOnEnemyScreen; ++i)
            {
                // newlines on the edges
                if (i % widthOnEnemyScreen == widthOnEnemyScreen -1 && i != 0)
                {
                    Console.WriteLine(EnemyScreenList[i]);
                }

                else
                {
                    Console.Write(EnemyScreenList[i]);
                }
            }
        }

        public void LoadPlayerActionBar()
        {
            OrginalPlayerScreen = System.IO.File.ReadAllLines(@"..\..\Player\PlayerActionBar.txt");
            PrintPlayerScreen = new char[OrginalPlayerScreen.Count() * OrginalPlayerScreen[1].Length];

            // TODO can change to fixed locations. 
            foreach (string item in OrginalPlayerScreen)
            {
                foreach (char character in item)
                {
                    PrintPlayerScreen[totalLengthPlayerAB] = character;
                    totalLengthPlayerAB++;
                }
            }
            heightActionBar = OrginalPlayerScreen.Count();
            WidthActionBar = OrginalPlayerScreen[1].Length;
        }

        private void RenderPlayerActionBar(Player player)
        {
            for (int i = 0; i < heightActionBar * WidthActionBar; ++i)
            {
                // newlines on the edges
                if (i % WidthActionBar == WidthActionBar - 1 && i != 0)
                {
                    Console.WriteLine(PrintPlayerScreen[i]);
                }

                else
                {
                    if (i == posHp)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(player.GetHealPoints());
                    }

                    else if (i == posCrystals)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(player.GetAmountCrystals());
                    }

                    else if (i == posAttack)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(player.AttackPower);
                    }

                    else if (i == posXpLeft)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(player.HowMuchXPToLevel());
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(PrintPlayerScreen[i]);
                    }
                }
            }
            Console.WriteLine("\n A = Attack, R = Run");
            char input = Console.ReadKey(true).KeyChar;
            UpdateLogic(input);
        }

        private void UpdateLogic(char input)
        {
            string inp = input.ToString().ToLower();

            switch (inp)
            {
                case "a":
                    
                    break;

            }
        }
        private void CheckIfWinning()
        {

        }
    }
}
