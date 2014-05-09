using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CarRental.DataModel.Infrastucture;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Messaging;
using CarRental.Infrastructure.Utils;
using Microsoft.Practices.Unity;

namespace CarRentalWebRole
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterFoundationInterface()
        {
            var container = GlobalUnityContainer.Instance;
            container.RegisterType<IObjectContextAdapter, CarRentalDatabaseContext>(new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new ContainerControlledLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommandBus, CommandBus>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>(new ContainerControlledLifetimeManager());
        }

        public class GlobalUnityContainer
        {
            /// <summary>
            /// The container
            /// </summary>
            private readonly static UnityContainer container = new UnityContainer();

            /// <summary>
            /// Gets the Instance.
            /// </summary>
            /// <value>The current.</value>
            public static UnityContainer Instance
            {
                get { return container; }
            }

            /// <summary>
            /// Initializes static members of the <see cref="GlobalUnityContainer" /> class.
            /// </summary>
            static GlobalUnityContainer()
            {
                Microsoft.Practices.ServiceLocation.ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
            }
        }
    }
}