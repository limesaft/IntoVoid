using IntoVoid.States;
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
            MainState main = new MainState();
            main.Run();
        }
    }
}
