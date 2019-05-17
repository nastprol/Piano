using System.Collections.Generic;
using System.Windows.Forms;
using Piano.Game.State;
using Ninject;
using Piano.Control;
using System.Drawing;
using System;

namespace Piano
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new StandardKernel();
            ContainerBinding(container, true, "1", true);

            Application.Run(container.Get<GameForm>());
        }

        public static void ContainerBinding(StandardKernel container, bool stdLoader, string loadPath, bool keyboardInput)
        {
            container.Bind<IGameMode>().To<ClassicMode>().InSingletonScope();
            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();

            if (stdLoader)
                container.Bind<IMelodyLoader>().To<StandardMelodyLoader>().InSingletonScope();
            else
                container.Bind<IMelodyLoader>().To<MelodyFileLoader>().InSingletonScope();
            container.Bind<Melody>().ToMethod(context => context.Kernel.Get<IMelodyLoader>().Load(loadPath)).InSingletonScope();
            container.Bind<IGame>().To<GameState>().InSingletonScope();

            if (keyboardInput)
            {
                container.Bind<IInputControl>().To<KeyBoardInputControl>().InSingletonScope();
                container.Bind<ISettings<Keys>>().To<KeyBoardSettings>().InSingletonScope();
                container.Bind<KeyBoardSettings>().ToSelf().InSingletonScope();
            }
            else
            {
                container.Bind<IInputControl>().To<MouseInputControl>().InSingletonScope();
                container.Bind<ISettings<Tuple<Point, Point>>>().To<MouseSettings>().InSingletonScope();
                container.Bind<MouseSettings>().ToSelf().InSingletonScope();
            }
            container.Bind<Controller>().ToSelf().InSingletonScope();
            container.Bind<MapSettings>().ToSelf().InSingletonScope();
            container.Bind<Map>().ToSelf().InSingletonScope();
            container.Bind<Form>().To<GameForm>().InSingletonScope();
        }
    }
}