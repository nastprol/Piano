using System.Linq;
using System.Windows.Forms;
using Ninject;
using Ninject.Extensions.Conventions;
using Domain;
using Domain.Infrastructure;
using System.Drawing;
using System;

namespace App
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new StandardKernel();
            ContainerBinding(container);
            var initialForm = container.Get<InitialForm>();
            Application.Run(initialForm);
        }

        public static void ContainerBinding(StandardKernel container)
        {
            container.Bind<GameSettings>().ToSelf().InSingletonScope();
            container.Bind<LoadConfig>().ToSelf().InSingletonScope();
            container.Bind<MapSettings>().ToSelf().InSingletonScope();
            container.Bind<KeySettings>().ToSelf().InSingletonScope();
            container.Bind<IMapChange>().To<RandKeyMapChange>().InSingletonScope();
            container.Bind<SoundsBase>().ToSelf().InSingletonScope();
            container.Bind<ILoaderSettings>().To<LoaderSettings>().InSingletonScope();

            container.Bind<SettingsForm>().ToSelf().InSingletonScope();

            container.Bind(x =>
                x.From(System.Reflection.Assembly.GetAssembly(typeof(IMelodyLoader))).SelectAllClasses().InheritedFrom<IMelodyLoader>().BindAllInterfaces());
            container.Bind<IInputControlChanger>().ToMethod(c => c.Kernel.Get<SettingsForm>()).InSingletonScope();
            container.Bind<ILoaderChanger>().ToMethod(c => c.Kernel.Get<SettingsForm>()).InSingletonScope();
            container.Bind<ILocationChanger>().ToMethod(c => c.Kernel.Get<SettingsForm>()).InSingletonScope();
            container.Bind<IModeChanger>().ToMethod(c => c.Kernel.Get<SettingsForm>()).InSingletonScope();
            container.Bind<LoaderSettings>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("loaders", container.GetAll<IMelodyLoader>().ToArray());

            container.Bind<Factory>().ToSelf().InSingletonScope().WithConstructorArgument("parentContainer", container);
            container.Bind<InitialForm>().ToSelf().InSingletonScope();
        }        
    }
}