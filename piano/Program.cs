using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Ninject.Extensions.Conventions;
using Piano.Control;
using Piano.Game.State;
using Piano.Loader;

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
            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();

            container.Bind<DescriptionAttribute>().ToSelf().InSingletonScope();
            container.Bind<VisualizationSettings>().ToSelf().InSingletonScope();
            container.Bind<KeyBoardSettings>().ToSelf().InSingletonScope();

            container.Bind<Map>().ToSelf().InSingletonScope();
            container.Bind<MapSettings>().ToSelf().InSingletonScope();
            container.Bind<Melody>().ToSelf().InSingletonScope();
            container.Bind<PianoKey>().ToSelf().InSingletonScope();
            container.Bind<Note>().ToSelf().InSingletonScope();
            container.Bind<InitialForm>().ToSelf().InSingletonScope();
            container.Bind<SettingsForm>().ToSelf().InSingletonScope();

            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IGameMode>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLoader>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IInputControl>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLocator>().BindAllInterfaces());

            container.Bind<IKeyInput>().To<GameForm>().InSingletonScope();
            container.Bind<IMouseInput>().To<GameForm>().InSingletonScope();
            container.Bind<KeyBoardInputControl>().ToSelf().InSingletonScope();
            container.Bind<MouseInputControl>().ToSelf().InSingletonScope();

            container.Bind<GameSettings>().ToSelf().InSingletonScope();
            //354

            container.Bind<IGame>().To<GameState>().InSingletonScope();
            container.Bind<LoadConfig>().ToSelf().InSingletonScope();

            container.Bind<Controller>().ToSelf().InSingletonScope();

            container.Bind<GameConstructor>().ToSelf().InSingletonScope();
            container.Bind<GameForm>().ToSelf().InSingletonScope();

            container.Bind<LoaderSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("loaders", container.GetAll<IMelodyLoader>().ToArray());

            container.Bind<LocatorSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("locators", container.GetAll<IMelodyLocator>().ToArray());

            container.Bind<InputControlSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("controls", container.GetAll<IInputControl>().ToArray());

            container.Bind<ModeConfig>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("modes", container.GetAll<IGameMode>().ToArray());
        }
    }
}