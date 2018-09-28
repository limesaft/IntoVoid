using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class GameBoard
    {
        private int width;
        private int height;
        private int playerX;
        private int playerY;

        private int mapSize;
        private int playerPos;
        private int oldPlayerPos;
        private int oldPlayerPosX;
        private int oldPlayerPosY;

        private int playerGoal;
        private int enemyPos;
        private int level = 1;
        private string[] BoardList;
        private char[] OrginalGameMap;
        private char[] PrintGameMap;

        //public int Width { get => width; set => width = value; }
        //public int Height { get => height; set => height = value; }
        //public List<string> TheBoardList { get => theBoardList; set => theBoardList = value; }

        public GameBoard(){}
    
        public void LoadLevel()
        {
            Console.Clear();

            height = 0;
            width = 0;
            mapSize = 0;
            playerX = 0;
            playerY = 0;

            BoardList = System.IO.File.ReadAllLines(@"..\..\Levels\level" + level.ToString() + ".txt");
            OrginalGameMap = new char[BoardList.Count()*BoardList[0].Length];
            PrintGameMap = new char[BoardList.Count() * BoardList[0].Length]; 

            int currentPosition = 0;
            foreach (string item in BoardList)
            {
                foreach (char character in item)
                {

                    if (character.ToString() == "@")
                    {
                        playerPos = currentPosition;
                        playerY = height;
                        
                    }
                    else
                    {
                        if (character.ToString() == "\\")
                        {
                            playerGoal = currentPosition;
                        }
                        if (character.ToString() == "E")
                        {
                            enemyPos = currentPosition;
                        }

                        OrginalGameMap[currentPosition] = character;

                    }

                    currentPosition++;
                }

                height++;
                width = item.Count();
                mapSize = currentPosition;
            }
            for (int i = 0; i < height * width; ++i)
            {
                // newlines on the edges
                if (i % width == width - 1 && i != 0)
                {
                    Console.WriteLine(OrginalGameMap[i]);
                }

                else
                {
                    if (i == playerPos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('@');
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(OrginalGameMap[i]);
                    }
                }
            }
        }

        // Move logic
        public void TryMovePlayer(char input)
        {
            oldPlayerPos = playerPos;

            if (input == 'd')
            {
                if (OrginalGameMap[playerPos + 1] != '#')
                {
                    //Array.Copy(OrginalGameMap, PrintGameMap, mapSize);
                    //OrginalGameMap[playerPos] = ' ';
                    //OrginalGameMap[playerPos + 1] = '@';
                    playerPos++;
                    //Console.WriteLine('@');

                }
            }

            if (input == 'a')
            {
                if (OrginalGameMap[playerPos - 1] != '#')
                {
                    //Array.Copy(OrginalGameMap, PrintGameMap, mapSize);
                    //OrginalGameMap[playerPos] = ' ';
                    //OrginalGameMap[playerPos - 1] = '@';
                    //Console.SetCursorPosition(mapSize % height,x);
                    playerPos--;
                }
            }

            if (input == 'w')
            {
                if (OrginalGameMap[playerPos - mapSize / height] != '#')
                {
                    //Array.Copy(OrginalGameMap, PrintGameMap, mapSize);
                    //OrginalGameMap[playerPos] = ' ';
                    //OrginalGameMap[playerPos - mapSize / height] = '@';
                    playerPos = playerPos - mapSize / height;
                }
            }

            if (input == 's')
            {
                if (OrginalGameMap[playerPos + mapSize / height] != '#')
                {
                    //Array.Copy(OrginalGameMap, PrintGameMap, mapSize);
                    //OrginalGameMap[playerPos] = ' ';
                    //OrginalGameMap[playerPos + mapSize / height] = '@';

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
            //

            //Array.Copy(OrginalGameMap, PrintGameMap, mapSize);
            /*
            Console.WriteLine(mapSize);
            Console.WriteLine(width);
            Console.WriteLine("PosX: " + playerPos % width);
            Console.WriteLine("PosY: " + playerPos / width);
            */
            //Console.WriteLine("\n w = up, s = down, a = left, d = right");

            oldPlayerPosX = oldPlayerPos % width;
            oldPlayerPosY = oldPlayerPos / width;
            Console.SetCursorPosition(oldPlayerPosX, oldPlayerPosY);
            Console.WriteLine(' ');
            Console.SetCursorPosition(playerX, playerY);

            playerX = playerPos % width;
            playerY = playerPos / width;
            Console.SetCursorPosition(playerX, playerY);
            Console.WriteLine('@');

        }

        public void RenderBoardAfterFight()
        {
            Console.Clear();

            for (int i = 0; i < height * width; ++i)
            {
                // newlines on the edges
                if (i % width == width - 1 && i != 0)
                {
                    Console.WriteLine(OrginalGameMap[i]);
                }

                else
                {
                    if (i == playerPos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('@');
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(OrginalGameMap[i]);
                    }
                }
            }
        }
    }
}
