using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class GameBoardcopey
    {
        private int width;
        private int height;

        private int mapSize;
        private int playerPos;
        private int playerGoal;
        private int enemyPos;
        private int level = 1;
        private List<string> theBoardList = new List<string>();
        private char[] ChartheBoardList;

        private string[] BoardList;

        //public int Width { get => width; set => width = value; }
        //public int Height { get => height; set => height = value; }
        public List<string> TheBoardList { get => theBoardList; set => theBoardList = value; }

        public GameBoardcopey(){}
    
        public void LoadLevel()
        {
            Console.Clear();

            height = 0;
            width = 0;
            mapSize = 0;
            TheBoardList.Clear();

            BoardList = System.IO.File.ReadAllLines(@"..\..\Levels\level" + level.ToString() + ".txt");
            ChartheBoardList = new char[BoardList.Count()];

            int length = ChartheBoardList.Count();

            int currentPosition = 0;


            foreach (string item in BoardList)
            {
                foreach (char character in item)
                {

                    ChartheBoardList[currentPosition] = character;
                    if (character.ToString() == "@")
                    {
                        playerPos = currentPosition;
                    }
                    if (character.ToString() == "\\")
                    {
                        playerGoal = currentPosition;
                    }
                    if (character.ToString() == "E")
                    {
                        enemyPos = currentPosition;
                    }
                    currentPosition++;
                }

                height++;
                width = item.Count();
                mapSize = currentPosition;
            }
        }

        // Move logic
        public void TryMovePlayer(string input)
        {
            if (input == "d")
            {
                if (TheBoardList[playerPos + 1].ToString() != "#")
                {
                    TheBoardList[playerPos] = " ";
                    TheBoardList[playerPos + 1] = "@";
                    playerPos++;
                }
            }

            if (input == "a")
            {
                if (TheBoardList[playerPos - 1].ToString() != "#")
                {
                    TheBoardList[playerPos] = " ";
                    TheBoardList[playerPos - 1] = "@";
                    playerPos--;
                }
            }

            if (input == "w")
            {
                if (TheBoardList[playerPos - mapSize / height].ToString() != "#")
                {
                    TheBoardList[playerPos] = " ";
                    TheBoardList[playerPos - mapSize / height] = "@";
                    playerPos = playerPos - mapSize / height;
                }
            }

            if (input == "s")
            {
                if (TheBoardList[playerPos + mapSize / height].ToString() != "#")
                {
                    TheBoardList[playerPos] = " ";
                    TheBoardList[playerPos + mapSize / height] = "@";
                    playerPos = playerPos + mapSize / height;
                }
            }
        }

        // Check if winning or new level
        public void CheckIfGoal()
        {
            // Check if at goal
            if(playerPos == playerGoal)
            {
                level++;
                LoadLevel();
            }
        }

        // Check if enemy
        public bool CheckIfEnemy()
        {
            if (playerPos == enemyPos)
            {
                enemyPos = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetLevel()
        {
            return level;
        }

        //TEST WRITEPLAYER, can be removed later on
        public void WritePlayerPos()
        {
            Console.WriteLine("PlayerPos: " + playerPos + "Goal " + playerGoal);
        }

        // Rending the board
        public void RenderBoard()
        {
            for(int i = 0; i < height*width; ++i)
            {
                // newlines on the edges
                if (i % width == width-1 && i != 0)
                {
                    Console.WriteLine(TheBoardList[i]);
                }

                else
                {
                    if(TheBoardList[i] == "@")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(TheBoardList[i]);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(TheBoardList[i]);
                    }
                }
            }
            Console.WriteLine("\n w = up, s = down, a = left, d = right");
        }
    }
}
