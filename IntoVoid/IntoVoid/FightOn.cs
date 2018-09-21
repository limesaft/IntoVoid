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


        private int height = 0;
        private int width = 0;
        private int totalLength = 0;
            
        public FightOn(int level)
        {
            currentLevel = level;
            EnemyScreen = System.IO.File.ReadAllLines(@"C:\Users\etheologou\source\repos\IntoVoid\IntoVoid\EnemyScreens\EnemyLow.txt");

            foreach (string item in EnemyScreen)
            {
                width = item.Count();
                height++;
            }
            totalLength = EnemyScreen.Length;
        }

        public void FightOnEvent(Player player)
        {
            while (ifFightOn)
            {
                LoadEnemyScreen();
                RenderPlayer();
                //Input
                UpdateLogic();

                ifFightOn = false;
                Console.ReadKey();
            }

            player.CheckLevelUp();
        }

        private void LoadEnemyScreen()
        {
            //Console.Clear();
            EnemyScreen = System.IO.File.ReadAllLines(@"C:\Users\etheologou\source\repos\IntoVoid\IntoVoid\EnemyScreens\EnemyLow.txt");
            Console.WriteLine(height + " <h w> " + width + "totalLength > " + totalLength);
            Console.ReadKey();
            for (int i = 0; i < height * width; ++i)
            {
                Console.WriteLine("jo");
                // newlines on the edges
                if (i % width == width - 1 && i != 0)
                {
                    Console.WriteLine(EnemyScreen[i]);
                }

                else
                {
                    if (EnemyScreen[i] == "@")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(EnemyScreen[i]);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(EnemyScreen[i]);
                    }
                }
            }
        }

        private void RenderPlayer()
        {

        }

        private void UpdateLogic()
        {

        }
    }
}
