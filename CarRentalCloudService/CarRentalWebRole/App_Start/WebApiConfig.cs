using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using CarRental.DataModel;
using CarRental.DataModel.Infrastucture;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Aggregate.Repository;
using CarRental.Infrastructure.Domain.Repository;
using CarRental.Infrastructure.Messaging;
using CarRental.Infrastructure.Utils;
using Microsoft.Practices.Unity;

namespace CarRentalWebRole
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();

            container.RegisterType<IObjectContextAdapter, CarRentalDatabaseContext>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<ICarRentalRepository, CarRentalRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICarRentalHistoryRepository, CarRentalHistoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICarRentalAvailablityCountView, CarRentalAvailablityCount>(new HierarchicalLifetimeManager());
            container.RegisterType<ICarRentalAvailablityView, CarRentalAvailablity>(new HierarchicalLifetimeManager());
            container.RegisterType<ILeastExpenseCarModelView, LeastExpenseCarModel>(new HierarchicalLifetimeManager());
            container.RegisterType<IPreferredCarModelView, PreferredCarModel>(new HierarchicalLifetimeManager());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            //container.RegisterType(typeof(CarRental.Event.DataModel.Infrastucture.IRepository<>), typeof(CarRental.Event.DataModel.Infrastucture.Repository<>));
            container.RegisterType<IEventBus, EventBus>(new HierarchicalLifetimeManager());
            container.RegisterType<IEventHandlerFactory, EventHandlerFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandBus, CommandBus>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "CarRental1",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

             config.Routes.MapHttpRoute(
              name: "CarRental",
              routeTemplate: "service/CarRental",
              defaults: new { controller = "CarRental", id = RouteParameter.Optional });

            


            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
