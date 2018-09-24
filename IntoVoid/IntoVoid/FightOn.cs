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
        private List<string> enemyScreenList = new List<string>();

        private int height = 0;
        private int width = 0;
        private int totalLength = 0;

        public List<string> EnemyScreenList { get => enemyScreenList; set => enemyScreenList = value; }

        public FightOn() { }


        public void FightOnEvent(Player player, int level)
        {
            LoadEnemyScreen(level);

            while (ifFightOn)
            {
                RenderFight();

                RenderPlayer();
                //Input here before logic
                UpdateLogic();

                //if enenyms dead fight = false;
                ifFightOn = false;
                Console.ReadKey();
            }

            player.CheckLevelUp();
        }

        private void LoadEnemyScreen(int level)
        {
            // Load the screen
            Console.Clear();
            ifFightOn = true;
            currentLevel = level;
            EnemyScreenList.Clear();

            //EnemyScreen = System.IO.File.ReadAllLines(@"C:\Users\etheologou\source\repos\IntoVoid\IntoVoid\EnemyScreens\EnemyLow.txt");

            EnemyScreen = System.IO.File.ReadAllLines(@"C:\Users\limesaft\Documents\Visual Studio 2017\Projects\IntoVoidRPGGame\IntoVoid\IntoVoid\IntoVoid\EnemyScreens\EnemyLow.txt");

            foreach (string item in EnemyScreen)
            {
                foreach (char character in item)
                {
                    EnemyScreenList.Add(character.ToString());
                }

                width = item.Count();
                height++;
            }

            totalLength = EnemyScreenList.Count();
        }

        private void RenderFight()
        {
            for (int i = 0; i < height * width; ++i)
            {
                // newlines on the edges
                if (i % width == width - 1 && i != 0)
                {
                    Console.WriteLine(EnemyScreenList[i]);
                }

                else
                {
                    Console.Write(EnemyScreenList[i]);
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
