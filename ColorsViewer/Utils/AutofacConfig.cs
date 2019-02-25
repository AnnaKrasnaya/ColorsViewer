using Autofac;
using Autofac.Integration.Mvc;
using ColorsViewer.DataAccess.Contracts;
using ColorsViewer.DataAccess.Repositories;
using ColorsViewer.Services.Contracts;
using ColorsViewer.Services.Services;
using System;
using System.Configuration;
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

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            String resolvedConnectionString = String.Empty;
            if (connectionString != null)
            {
                resolvedConnectionString = connectionString.ConnectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            }

            builder.RegisterType<ColorsRepository>().As<IColorsRepository>().WithParameter(new NamedParameter("connectionString", resolvedConnectionString));

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}