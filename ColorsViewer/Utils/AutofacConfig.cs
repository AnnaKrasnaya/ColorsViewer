using Autofac;
using Autofac.Integration.Mvc;
using ColorsViewer.DataAccess.Contracts;
using ColorsViewer.DataAccess.Repositories;
using ColorsViewer.Services.Contracts;
using ColorsViewer.Services.Services;
using System.Web.Mvc;

namespace ColorsViewer.Utils
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ColorsService>().As<IColorsService>();
            builder.RegisterType<ColorsRepository>().As<IColorsRepository>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}