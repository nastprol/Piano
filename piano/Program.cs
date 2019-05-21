using System.Drawing;
using System.Windows.Forms;
using Ninject;
using Piano.Control;
using Piano.Game.State;

namespace Piano
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new StandardKernel();
            ContainerBinding(container, false, false);

            Application.Run(container.Get<GameForm>());
        }

        public static void ContainerBinding(StandardKernel container, bool stdLoader,
            bool keyboardInput)
        {
            container.Bind<IMelodyLocator>().To<FileLocator>().InSingletonScope().WithConstructorArgument("1.txt");
            container.Bind<IGameMode>().To<ClassicMode>().InSingletonScope();
            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();

            if (stdLoader)
                container.Bind<IMelodyLoader>().To<StandardMelodyLoader>().InSingletonScope();
            else
                container.Bind<IMelodyLoader>().To<MelodyFileLoader>().InSingletonScope();
            container.Bind<Melody>().ToMethod(context =>
                {
                    var locator = context.Kernel.Get<IMelodyLocator>();
                    return context.Kernel.Get<IMelodyLoader>().Load(locator);
                })
                .InSingletonScope();
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
                container.Bind<ISettings<(Point, Point)>>().To<VisualizationSettings>().InSingletonScope();
                container.Bind<VisualizationSettings>().ToSelf().InSingletonScope();
            }

            container.Bind<Controller>().ToSelf().InSingletonScope();
            container.Bind<MapSettings>().ToSelf().InSingletonScope();
            container.Bind<Map>().ToSelf().InSingletonScope();
            container.Bind<Form>().To<GameForm>().InSingletonScope();
        }
    }
}