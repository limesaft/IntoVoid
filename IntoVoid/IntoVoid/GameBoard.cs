﻿using System;
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
        private int totalLength;
        private int playerPos;
        private int playerGoal;
        private int enemyPos;
        private int level = 0;
        private List<string> theBoardList = new List<string>();
        private string[] BoardList;

        //public int Width { get => width; set => width = value; }
        //public int Height { get => height; set => height = value; }
        public List<string> TheBoardList { get => theBoardList; set => theBoardList = value; }

        public GameBoard(){}
    
        public void LoadLevel()
        {
            Console.Clear();

            height = 0;
            width = 0;
            totalLength = 0;
            TheBoardList.Clear();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(path);

            //BoardList = System.IO.File.ReadAllLines(@"C:\Users\etheologou\source\repos\IntoVoid\IntoVoid\Levels\level" + level.ToString() +".txt");
            BoardList = System.IO.File.ReadAllLines(@"C: \Users\limesaft\Documents\Visual Studio 2017\Projects\IntoVoidRPGGame\IntoVoid\IntoVoid\IntoVoid\Levels\level" + level.ToString() + ".txt");

            int x = 0;

            foreach (string item in BoardList)
            {
                foreach (char character in item)
                {
                    TheBoardList.Add(character.ToString());
                    if (character.ToString() == "@")
                    {
                        playerPos = x;
                    }
                    if (character.ToString() == "\\")
                    {
                        playerGoal = x;
                    }
                    if (character.ToString() == "E")
                    {
                        enemyPos = x;
                    }
                    x++;
                }

                height++;
                width = item.Count();
                totalLength = x;
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
                if (TheBoardList[playerPos - totalLength/height].ToString() != "#")
                {
                    TheBoardList[playerPos] = " ";
                    TheBoardList[playerPos - totalLength / height] = "@";
                    playerPos = playerPos - totalLength / height;
                }
            }

            if (input == "s")
            {
                if (TheBoardList[playerPos + totalLength / height].ToString() != "#")
                {
                    TheBoardList[playerPos] = " ";
                    TheBoardList[playerPos + totalLength / height] = "@";
                    playerPos = playerPos + totalLength / height;
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
                        Console.ForegroundColor = ConsoleColor.Cyan;
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
