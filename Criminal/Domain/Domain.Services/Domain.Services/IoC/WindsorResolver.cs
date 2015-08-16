using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Domain.Interfaces;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Factory
{
    public class WindsorResolver<T>
    {
        static IWindsorContainer container;
        public static T Resolve() 
        {
            InstallIoC();
            var consumer = container.Resolve<T>();
            return consumer;
        }
        private static void InstallIoC() 
        {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
            container.Register(Component.For<ICriminalRepository>().ImplementedBy<RepositoryCriminal>());
            container.Register(Component.For<ICriminalService>().ImplementedBy<ServiceCriminal>());
            container.Register(Component.For<ICountryRepository>().ImplementedBy<RepositoryCountry>());
            container.Register(Component.For<ISexTypeRepository>().ImplementedBy<RepositorySexType>());
            // container.Install(Castle.Windsor.Installer.Configuration.FromAppConfig());
            container.Install();
        
        }
    }
}
