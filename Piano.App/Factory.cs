using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;
using Domain;

namespace App
{
    public class Factory
    {
        private readonly StandardKernel parentContainer;

        public Factory(StandardKernel parentContainer)
        {
            this.parentContainer = parentContainer;
        }

        public Constructor GetNew()
        {
            var container = new Ninject.Extensions.ChildKernel.ChildKernel(parentContainer);
            container.Bind<IModeSettings>().To<ModeSettings>().InSingletonScope();

            container.Bind<Map>().ToSelf().InSingletonScope();

            container.Bind(x => x.From(System.Reflection.Assembly.GetAssembly(typeof(IGameMode))).SelectAllClasses().InheritedFrom<IGameMode>().BindAllInterfaces());
            container.Bind<ModeSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("modes", container.GetAll<IGameMode>().ToArray());
            container.Bind<GameState>().ToSelf().InSingletonScope().WithConstructorArgument("shift", container.Get<KeySettings>().Height);

            container.Bind<GameForm>().ToSelf().InSingletonScope();
            container.Bind<IMouseInput>().ToMethod(c => c.Kernel.Get<GameForm>()).InSingletonScope();
            container.Bind<IKeyInput>().ToMethod(c => c.Kernel.Get<GameForm>()).InSingletonScope();
            container.Bind<VisualizationSettings>().ToSelf().InSingletonScope();
            container.Bind<KeyBoardSettings>().ToSelf().InSingletonScope();
            container.Bind(x =>
                x.From(System.Reflection.Assembly.GetAssembly(typeof(IInputControl))).SelectAllClasses().InheritedFrom<IInputControl>().BindAllInterfaces());
            container.Bind<InputControlSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("controls", container.GetAll<IInputControl>().ToArray());
            container.Bind<Controller>().ToSelf().InSingletonScope();

            return container.Get<Constructor>();
        }
    }
}
