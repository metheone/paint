using Autofac;
using Paint.Data.Interface;
using Paint.Data.Repository;
using Paint.Model.common;
using Paint.Service;
using Paint.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintDesktopConsole
{
    static class Program
    {
        static IContainer _iocContainer;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureAutoFac();

            using (var scope = _iocContainer.BeginLifetimeScope())
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main(scope.Resolve<IPaintService>()));
            }
        }
        private static void ConfigureAutoFac()
        {
            ContainerBuilder builder = new ContainerBuilder();

            // Data context
            builder.RegisterType<Settings>().As<ISettings>()
               .WithParameter("databaseConnectionString", "DefaultConnection");

            builder.RegisterType<ColorRepository>().As<IColorRepository>().UsingConstructor(typeof(ISettings));
            builder.RegisterType<DefectRepository>().As<IDefectRepository>().UsingConstructor(typeof(ISettings));
            builder.RegisterType<ManufacturerRepository>().As<IManufacturerRepository>().UsingConstructor(typeof(ISettings));
            builder.RegisterType<MixRoomRepository>().As<IMixRoomRepository>().UsingConstructor(typeof(ISettings));
            builder.RegisterType<PartLogRepository>().As<IPartLogRepository>().UsingConstructor(typeof(ISettings));
            builder.RegisterType<PartRepository>().As<IPartRepository>().UsingConstructor(typeof(ISettings));
            builder.RegisterType<SolventRepository>().As<ISolventRepository>().UsingConstructor(typeof(ISettings));
            
            builder.RegisterType<PaintService>().As<IPaintService>().InstancePerLifetimeScope();
            
            _iocContainer = builder.Build();
        }
    
}
}
