using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class MainGame
    {
        static void Main(string[] args)
        {
            var board = new GameBoard();
            Player player = new Player();

            bool ifGameOn = true;
            bool ifFightOn = false;

            board.LoadLevel();

            //bool fight = false;
            while (ifGameOn) 
            {
                // render the map
                Console.Clear();
                board.RenderBoard();
                board.WritePlayerPos();


                // player can move
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                board.TryMovePlayer(input.ToString());

                // Check if new level
                board.CheckIfGoal();
                ifFightOn = board.CheckIfEnemy();

                if (ifFightOn)
                {
                    FightOn fightOn = new FightOn(board.GetLevel());
                    fightOn.FightOnEvent(player);

                    ifFightOn = false;
                }

                // For testing stuff can be removed later on
                board.WritePlayerPos();

            }

            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
