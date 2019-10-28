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
        private int _width;
        private int _height;
        private int _playerX;
        private int _playerY;

        private int _mapSize;
        private int _playerPos;
        private int _oldPlayerPos;
        private int _oldPlayerPosX;
        private int _oldPlayerPosY;

        private int playerGoal;
        private int enemyPos;
        private int level = 0;
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

            _height = 0;
            _width = 0;
            _mapSize = 0;
            _playerX = 0;
            _playerY = 0;

            BoardList = System.IO.File.ReadAllLines(@"..\..\Levels\level" + level.ToString() + ".txt");

            OrginalGameMap = new char[BoardList.Count()*BoardList[0].Length];
            PrintGameMap = new char[BoardList.Count() * BoardList[0].Length];

            CheckCurrentMapSizes();
            RenderStartingBoard();
        }
        
        public void RenderStartingBoard()
        {
            for (int i = 0; i < _height * _width; ++i)
            {
                // newlines on the edges
                if (i % _width == _width - 1 && i != 0)
                {
                    Console.WriteLine(OrginalGameMap[i]);
                }
                else
                {
                    if (i == _playerPos)
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
        public void CheckCurrentMapSizes()
        {
            int currentPosition = 0;

            foreach (string item in BoardList)
            {
                foreach (char character in item)
                {

                    if (character.ToString() == "@")
                    {
                        _playerPos = currentPosition;
                        _playerY = _height;

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

                _height++;
                _width = item.Count();
                _mapSize = currentPosition;
            }

        }
        // Move logic
        public void TryMovePlayer()
        {
            char input = Console.ReadKey(true).KeyChar;

            _oldPlayerPos = _playerPos;

            if (input == 'd')
            {
                if (OrginalGameMap[_playerPos + 1] != '#')
                {
                    _playerPos++;

                }
            }

            if (input == 'a')
            {
                if (OrginalGameMap[_playerPos - 1] != '#')
                {
                    _playerPos--;
                }
            }

            if (input == 'w')
            {
                if (OrginalGameMap[_playerPos - _mapSize / _height] != '#')
                {
                    _playerPos = _playerPos - _mapSize / _height;
                }
            }

            if (input == 's')
            {
                if (OrginalGameMap[_playerPos + _mapSize / _height] != '#')
                {
                    _playerPos = _playerPos + _mapSize / _height;
                }
            }
            // Check for next level
            CheckIfNextLevel();
        }

        private void CheckIfNextLevel()
        {
            // Check if at goal
            if(_playerPos == playerGoal)
            {
                level++;
                LoadLevel();
            }
        }

        // Check if enemy
        public bool CheckIfEnemy()
        {
            if (_playerPos == enemyPos)
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
            Console.WriteLine("PlayerPos: " + _playerPos + "Goal " + playerGoal);
        }

        // Rending the board on specific locations
        public void RenderBoardChanges()
        {
            _oldPlayerPosX = _oldPlayerPos % _width;
            _oldPlayerPosY = _oldPlayerPos / _width;
            Console.SetCursorPosition(_oldPlayerPosX, _oldPlayerPosY);
            Console.WriteLine(' ');
            Console.SetCursorPosition(_playerX, _playerY);

            _playerX = _playerPos % _width;
            _playerY = _playerPos / _width;
            Console.SetCursorPosition(_playerX, _playerY);
            Console.WriteLine('@');
        }

        public void RenderBoardAfterFight()
        {
            Console.Clear();

            for (int i = 0; i < _height * _width; ++i)
            {
                // newlines on the edges
                if (i % _width == _width - 1 && i != 0)
                {
                    Console.WriteLine(OrginalGameMap[i]);
                }
                else
                {
                    if (i == _playerPos)
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
