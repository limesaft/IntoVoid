
namespace IntoVoid.States
{
    class MainState
    {
        private readonly bool ifGameOn = true;

        public void Run()
        {
            var board = new GameBoard();
            Player player = new Player();
            FightState fightOn = new FightState();

            board.LoadLevel();
            //Console.CursorVisible = false;

            while (ifGameOn)
            {
                board.RenderBoardChanges();
                board.TryMovePlayer();

                if (board.CheckIfEnemy())
                {
                    fightOn.FightOnEvent(player, board.GetLevel());
                    board.RenderBoardAfterFight();
                } 
            }

            // Suspend the screen when game is over
            System.Console.ReadLine();
        }
    }
}
