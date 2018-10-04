using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid.States
{
    class MainState
    {
        public void Run()
        {
            var board = new GameBoard();
            Player player = new Player();

            bool ifGameOn = true;
            bool ifFightOn = false;

            board.LoadLevel();
            //Console.CursorVisible = false;

            while (ifGameOn)
            {
                // render the map
                //Console.Clear();
                board.RenderBoard();
                //board.WritePlayerPos();

                // player can move
                char input = Console.ReadKey(true).KeyChar;
                Console.WriteLine();
                board.TryMovePlayer(input);

                // Check if new level
                board.CheckIfGoal();

                // Check if found an enemy
                ifFightOn = board.CheckIfEnemy();

                if (ifFightOn)
                {
                    FightState fightOn = new FightState();
                    fightOn.FightOnEvent(player, board.GetLevel());

                    ifFightOn = false;
                    board.RenderBoardAfterFight();
                }
            }

            // Suspend the screen when game is over
            System.Console.ReadLine();
        }
    }
}
