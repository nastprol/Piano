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
            ContainerBinding(container);

            var constructor = container.Get<GameConstructor>();
            var loadConfig = container.Get<LoadConfig>();
            var settings = container.Get<GameSettings>();

            Application.Run(new InitialForm(constructor.Form, settings, loadConfig));
        }

        public static void ContainerBinding(StandardKernel container)
        {
            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();

            container.Bind<ISettings<Keys>>().To<KeyBoardSettings>().InSingletonScope();
            container.Bind<ISettings<(Point, Point)>>().To<VisualizationSettings>().InSingletonScope();


            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IGameMode>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLoader>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IInputControl>().BindAllInterfaces());
            container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IMelodyLocator>().BindAllInterfaces());


            container.Bind<IKeyInput>().To<GameForm>();
            container.Bind<IMouseInput>().To<GameForm>();

            container.Bind<IGame>().To<GameState>().InSingletonScope();
            

            container.Bind<LoadConfig>().ToSelf().InSingletonScope();

            container.Bind<GameSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("loaders", container.GetAll<IMelodyLoader>().ToArray())
                .WithConstructorArgument("inputControls", container.GetAll<IInputControl>().ToArray())
                .WithConstructorArgument("modes", container.GetAll<IGameMode>().ToArray())
                .WithConstructorArgument("locators", container.GetAll<IMelodyLocator>().ToArray());
            
        }
    }
}

/*
 * ActivationException: Error activating GameSettings using self-binding of GameSettings
A cyclical dependency was detected between the constructors of two services.

Activation path:
  6) Injection of dependency GameSettings into parameter settings of constructor of type GameState
  5) Injection of dependency IGame into parameter state of constructor of type GameForm
  4) Injection of dependency IKeyInput into parameter input of constructor of type KeyBoardInputControl
  3) Injection of dependency IInputControl into parameter inputControls of constructor of type GameSettings
  2) Injection of dependency GameSettings into parameter settings of constructor of type MelodyFileLoader
  1) Request for IMelodyLoader

Suggestions:
  1) Ensure that you have not declared a dependency for GameSettings on any implementations of the service.
  2) Consider combining the services into a single one to remove the cycle.
  3) Use property injection instead of constructor injection, and implement IInitializable
     if you need initialization logic to be run after property values have been injected.


 * 
 * ActivationException: Error activating GameSettings using self-binding of GameSettings
A cyclical dependency was detected between the constructors of two services.

Activation path:
  7) Injection of dependency GameSettings into parameter gameSettings of constructor of type Map
  6) Injection of dependency Map into parameter map of constructor of type GameState
  5) Injection of dependency IGame into parameter state of constructor of type GameForm
  4) Injection of dependency IKeyInput into parameter input of constructor of type KeyBoardInputControl
  3) Injection of dependency IInputControl into parameter inputControls of constructor of type GameSettings
  2) Injection of dependency GameSettings into parameter settings of constructor of type MelodyFileLoader
  1) Request for IMelodyLoader

Suggestions:
  1) Ensure that you have not declared a dependency for GameSettings on any implementations of the service.
  2) Consider combining the services into a single one to remove the cycle.
  3) Use property injection instead of constructor injection, and implement IInitializable
     if you need initialization logic to be run after property values have been injected.




 * ActivationException: Error activating IInputControl using binding from IInputControl to KeyBoardInputControl
A cyclical dependency was detected between the constructors of two services.

Activation path:
  6) Injection of dependency IInputControl into parameter inputControls of constructor of type GameSettings
  5) Injection of dependency GameSettings into parameter gameSettings of constructor of type Map
  4) Injection of dependency Map into parameter map of constructor of type GameState
  3) Injection of dependency IGame into parameter state of constructor of type GameForm
  2) Injection of dependency IKeyInput into parameter input of constructor of type KeyBoardInputControl
  1) Request for IInputControl

Suggestions:
  1) Ensure that you have not declared a dependency for IInputControl on any implementations of the service.
  2) Consider combining the services into a single one to remove the cycle.
  3) Use property injection instead of constructor injection, and implement IInitializable
     if you need initialization logic to be run after property values have been injected.


 */
