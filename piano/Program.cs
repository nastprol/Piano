using System.Collections.Generic;
using System.Windows.Forms;
using Piano.Game.State;
using Ninject;

namespace Piano
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new StandardKernel();
            container.Bind<IGameMode>().To<ArcadeMode>().InSingletonScope();
            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();
            container.Bind<IMelodyLoader>().To<StandardMelodyLoader>().InSingletonScope();
            container.Bind<Melody>().ToMethod(context => context.Kernel.Get<IMelodyLoader>().Load("1")).InSingletonScope();
            container.Bind<IGame>().To<GameState>().InSingletonScope();
            container.Bind<IInputControl>().To<KeyBoardInputControl>().InSingletonScope();
            container.Bind<KeyBoardSettings>().ToSelf().InSingletonScope();
            container.Bind<Controller>().ToSelf().InSingletonScope();
            container.Bind<MapSettings>().ToSelf().InSingletonScope();
            container.Bind<Map>().ToSelf().InSingletonScope();
            container.Bind<Form>().To<GameForm>().InSingletonScope();

            Application.Run(container.Get<GameForm>());
        }
    }
}