using System.Linq;
using System.Windows.Forms;
using Ninject;
using Ninject.Extensions.Conventions;
using Domain;

namespace App
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
            container.Bind<GameSettings>().ToSelf().InSingletonScope();
            container.Bind<LoadConfig>().ToSelf().InSingletonScope();
            container.Bind<MapSettings>().ToSelf().InSingletonScope();
            container.Bind<KeySettings>().ToSelf().InSingletonScope();
            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();
            container.Bind<IModeSettings>().To<ModeSettings>().InSingletonScope();
            container.Bind<ILoaderSettings>().To<LoaderSettings>().InSingletonScope();
            container.Bind<SettingsForm>().ToSelf().InSingletonScope();
            container.Bind<IInputControlChanger>().ToMethod(c => c.Kernel.Get<SettingsForm>()).InSingletonScope();
            container.Bind<ILoaderChanger>().ToMethod(c => c.Kernel.Get<SettingsForm>()).InSingletonScope();
            container.Bind<ILocationChanger>().ToMethod(c => c.Kernel.Get<SettingsForm>()).InSingletonScope();
            container.Bind<IModeChanger>().ToMethod(c => c.Kernel.Get<SettingsForm>()).InSingletonScope();
            container.Bind<MelodyFileLoader>().ToSelf().InSingletonScope();
            container.Bind<StandardMelodyLoader>().ToSelf().InSingletonScope();
            container.Bind(x =>
                x.From(System.Reflection.Assembly.GetAssembly(typeof(IMelodyLoader))).SelectAllClasses().InheritedFrom<IMelodyLoader>().BindAllInterfaces());
            container.Bind<LoaderSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("loaders", container.GetAll<IMelodyLoader>().ToArray());
            container.Bind<Map>().ToSelf().InSingletonScope();
            container.Bind<ClassicMode>().ToSelf().InSingletonScope();
            container.Bind<ArcadeMode>().ToSelf().InSingletonScope();
            container.Bind(x => x.From(System.Reflection.Assembly.GetAssembly(typeof(IGameMode))).SelectAllClasses().InheritedFrom<IGameMode>().BindAllInterfaces());
            container.Bind<ModeSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("modes", container.GetAll<IGameMode>().ToArray());
            container.Bind<GameState>().ToSelf().InSingletonScope();
            container.Bind<SoundsBase>().ToSelf().InSingletonScope();
            container.Bind<GameForm>().ToSelf().InSingletonScope();
            container.Bind<IMouseInput>().ToMethod(c => c.Kernel.Get<GameForm>()).InSingletonScope();
            container.Bind<IKeyInput>().ToMethod(c => c.Kernel.Get<GameForm>()).InSingletonScope();
            container.Bind<VisualizationSettings>().ToSelf().InSingletonScope();
            container.Bind<KeyBoardSettings>().ToSelf().InSingletonScope();
            container.Bind<KeyBoardInputControl>().ToSelf().InSingletonScope();
            container.Bind<MouseInputControl>().ToSelf().InSingletonScope();
            container.Bind(x =>
                x.From(System.Reflection.Assembly.GetAssembly(typeof(IInputControl))).SelectAllClasses().InheritedFrom<IInputControl>().BindAllInterfaces());
            container.Bind<InputControlSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("controls", container.GetAll<IInputControl>().ToArray());
            container.Bind<Controller>().ToSelf().InSingletonScope();
            container.Bind<InitialForm>().ToSelf().InSingletonScope();
        }
    }
}