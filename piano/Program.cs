using System.Drawing;
using System.Linq;
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
            ContainerBinding(container, false, false);

            var constructor = container.Get<GameConstructor>();
            var loadConfig = container.Get<LoadConfig>();
            var settings = container.Get<GameSettings>();

            Application.Run(new InitialForm(constructor.Form, settings, loadConfig));
        }

        public static void ContainerBinding(StandardKernel container, bool stdLoader,
            bool keyboardInput)
        {
            //  container.Bind<IMelodyLocator>().To<FileLocator>().InSingletonScope().WithConstructorArgument("1.txt");
            //container.Bind<IGameMode>().To<ClassicMode>().InSingletonScope();


            //container.Bind<IGameMode>().ToSelf().InSingletonScope();
            //container.Bind<IMelodyLoader>().ToSelf().InSingletonScope();
            //container.Bind<IInputControl>().ToSelf().InSingletonScope();
            //container.Bind<IMelodyLocator>().ToSelf().InSingletonScope();


            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IGameMode>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLoader>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IInputControl>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLocator>().BindAllInterfaces());


            //container.Bind(c => c.FromThisAssembly().SelectAllClasses().InheritedFrom<IGameMode>().BindToSelf());
            //container.Bind(c => c.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLoader>().BindToSelf());
            //container.Bind(c => c.FromThisAssembly().SelectAllClasses().InheritedFrom<IInputControl>().BindToSelf());
            //container.Bind(c => c.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLocator>().BindToSelf());


            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();

            //if (stdLoader)
            //    container.Bind<IMelodyLoader>().To<StandardMelodyLoader>().InSingletonScope();
            //else
            //    container.Bind<IMelodyLoader>().To<MelodyFileLoader>().InSingletonScope();


            container.Bind<Melody>().ToMethod(context =>
                {
                    var locator = context.Kernel.Get<IMelodyLocator>();
                    return context.Kernel.Get<IMelodyLoader>().Load(locator);
                })
                .InSingletonScope();

            container.Bind<IGame>().To<GameState>().InSingletonScope();

            //if (keyboardInput)
            //    container.Bind<IInputControl>().To<KeyBoardInputControl>().InSingletonScope();
            //else
            //    container.Bind<IInputControl>().To<MouseInputControl>().InSingletonScope();

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
            container.Bind<GameSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("inputControls", container.GetAll<IInputControl>().ToArray())
                .WithConstructorArgument("modes", container.GetAll<IGameMode>().ToArray())
                .WithConstructorArgument("loaders", container.GetAll<IMelodyLoader>().ToArray());


            container.Bind<ClassicMode>().ToSelf().InSingletonScope();
            container.Bind<ArcadeMode>().ToSelf().InSingletonScope();
            //container.Bind<KeyBoardSettings>().ToSelf().InSingletonScope();
            //container.Bind<KeyBoardSettings>().ToSelf().InSingletonScope();

        }
    }
}