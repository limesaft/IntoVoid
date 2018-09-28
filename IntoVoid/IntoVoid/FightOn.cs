using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class FightOn
    {
        private int currentLevel;
        private bool ifFightOn = true;
        private string[] EnemyScreen;
        public List<string> EnemyScreenList { get => _enemyScreenList; set => _enemyScreenList = value; }

        private char[] PrintPlayerScreen;
        private string[] OrginalPlayerScreen;

        private List<string> _enemyScreenList = new List<string>();

        private int heightES = 0;
        private int widthES = 0;
        private int totalLengthES = 0;

        private int widthAB = 0;
        private int heightAB = 0;
        private int totalLengthPlayerAB = 0;

        // position for actionbar,
        private int posHp = 0;
        private int posAttack = 0;
        private int posXpLeft = 0;
        private int posCrystals = 0;

        public FightOn() { }


        public void FightOnEvent(Player player, int level)
        {
            LoadEnemyScreen(level);
            RenderEnemyScreen();
            LoadPlayerActionBar();

            while (ifFightOn)
            {
                RenderPlayerActionBar(player);

                //Input here before logic
                UpdateLogic();

                //if enenyms dead fight = false;
                ifFightOn = false;
                Console.ReadKey();
            }
            // enemy worth in XP;
            player.CheckLevelUp(5);
        }

        private void LoadEnemyScreen(int level)
        {
            // Load the screen
            Console.Clear();
            ifFightOn = true;
            currentLevel = level;
            EnemyScreenList.Clear();

            EnemyScreen = System.IO.File.ReadAllLines(@"..\..\EnemyScreens\EnemyLow.txt");

            foreach (string item in EnemyScreen)
            {
                foreach (char character in item)
                {
                    EnemyScreenList.Add(character.ToString());
                    totalLengthES++;
                }

                widthES = item.Count();
                heightES++;
            }

            totalLengthES = EnemyScreenList.Count();
        }

        private void RenderEnemyScreen()
        {
            for (int i = 0; i < heightES * widthES; ++i)
            {
                // newlines on the edges
                if (i % widthES == widthES - 1 && i != 0)
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

            foreach (string item in OrginalPlayerScreen)
            {
                foreach (char character in item)
                {
                    if (character == '1')
                    {
                        posHp = totalLengthPlayerAB;
                    }
                    if (character == '2')
                    {
                        posAttack = totalLengthPlayerAB;
                    }
                    if (character == '3')
                    {
                        posCrystals = totalLengthPlayerAB;
                    }

                    if (character == '4')
                    {
                        posXpLeft = totalLengthPlayerAB;
                    }        


                    PrintPlayerScreen[totalLengthPlayerAB] = character;
                    totalLengthPlayerAB++;
                }
            }
            heightAB = OrginalPlayerScreen.Count();
            widthAB = OrginalPlayerScreen[1].Length;
        }

        private void RenderPlayerActionBar(Player player)
        {

            for (int i = 0; i < heightAB * widthAB; ++i)
            {
                // newlines on the edges
                if (i % widthAB == widthAB - 1 && i != 0)
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

        }

        /*
        oldPlayerPosX = oldPlayerPos % width;
        oldPlayerPosY = oldPlayerPos / width;
        Console.SetCursorPosition(oldPlayerPosX, oldPlayerPosY);
        Console.WriteLine(' ');
        Console.SetCursorPosition(playerX, playerY);

        playerX = playerPos % width;
        playerY = playerPos / width;
        Console.SetCursorPosition(playerX, playerY);
        Console.WriteLine('@');
        */
        // se över totallength som playerposition X och y

        //Console.SetCursorPosition(totalLength, totalLength);
        //Console.WriteLine("lastet");


        private void UpdateLogic()
        {

        }
    }
}
