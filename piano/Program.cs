using System.Drawing;
using System.Windows.Forms;
using Ninject;
using Ninject.Extensions.Conventions;
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
            ContainerBinding(container);

            Application.Run(container.Get<InitialForm>());
        }

        public static void ContainerBinding(StandardKernel container)
        {
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IGameMode>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLoader>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IInputControl>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLocator>().BindAllInterfaces());

            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();
            container.Bind<IGame>().To<GameState>().InSingletonScope();

            container.Bind<Melody>().ToMethod(context =>
                {
                    var locator = context.Kernel.Get<IMelodyLocator>();
                    return context.Kernel.Get<IMelodyLoader>().Load(locator);
                })
                .InSingletonScope();

            container.Bind<ISettings<Keys>>().To<KeyBoardSettings>().InSingletonScope();
            container.Bind<ISettings<(Point, Point)>>().To<VisualizationSettings>().InSingletonScope();


            container.Bind<IKeyInput>().ToMethod(context => context.Kernel.Get<GameForm>());
            container.Bind<IMouseInput>().ToMethod(context => context.Kernel.Get<GameForm>());
            container.Bind<KeyBoardSettings>().ToSelf().InSingletonScope();
            container.Bind<VisualizationSettings>().ToSelf().InSingletonScope();
            container.Bind<Controller>().ToSelf().InSingletonScope();
            container.Bind<MapSettings>().ToSelf().InSingletonScope();
            container.Bind<Map>().ToSelf().InSingletonScope();
            container.Bind<GameForm>().ToSelf().InSingletonScope();
            container.Bind<LoadConfig>().ToSelf().InSingletonScope();
            container.Bind<GameSettings>().ToSelf().InSingletonScope();
        }
    }
}