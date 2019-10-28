using IntoVoid.States;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace IntoVoid
{
    class MainGame
    {
        static void Main(string[] args)
        {
           // var container = new WindsorContainer();
           // container.Register(Component.For<>)

            MainState main = new MainState();
            main.Run();
        }
    }
}
