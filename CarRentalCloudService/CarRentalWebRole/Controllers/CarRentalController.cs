using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Web.Http;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Aggregate.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.Domain.Repository;
using CarRental.Infrastructure.Messaging;
using CarRental.Infrastructure.Utils;

namespace CarRentalWebRole.Controllers
{
    public class CarRentalController : ApiController
    {
        ICommandBus Channel;

        public CarRentalController(ICommandBus IChannel)
        {
            this.Channel = IChannel;
        }

        public void Get()
        {
        }

        // GET 
        public HttpResponseMessage Get(string queryMode)
        {
            HttpResponseMessage httpresponseMessage = new HttpResponseMessage();
            var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
            var carRentalAvailablity = RepositoryFactory.Current.Get<ICarRentalAvailablityView>();
            var favouritecar = RepositoryFactory.Current.Get<IPreferredCarModelView>();
            var leastexpensive = RepositoryFactory.Current.Get<ILeastExpenseCarModelView>();
            PreferredCarModelView preferredCarModelView = new PreferredCarModelView();
            LeastExpenseCarModelView leastExpenseCarModelView = new LeastExpenseCarModelView();
            List<CarRentalAvailablityView> lstCarRentalAvail = new List<CarRentalAvailablityView>();

            switch (queryMode)
            {
                case "returntoday":
                    lstCarRentalAvail = carRentalAvailablity.GetAll().Where(x => x.CarRentalEndDate.Value.Date == DateTime.Today).ToList();
                    httpresponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, lstCarRentalAvail);
                    break;
                case "senttoday":
                    lstCarRentalAvail = carRentalAvailablity.GetAll().Where(x => x.CarRentalStartDate.Value.Date == DateTime.Today).ToList();
                    httpresponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, lstCarRentalAvail);
                    break;
                case "favourite":
                    preferredCarModelView = favouritecar.GetAll().OrderByDescending(x => x.RentedCount).FirstOrDefault();
                    httpresponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, preferredCarModelView);
                    break;
                case "leastexpense":
                    leastExpenseCarModelView = leastexpensive.GetAll().OrderBy(x => x.Cost).FirstOrDefault();
                    httpresponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, leastExpenseCarModelView);
                    break;
            }

            return httpresponseMessage;

        }

        public string Get(string modelName, string date)
        {
            string carModelAvailable = string.Empty;
            if (!string.IsNullOrEmpty(date))
            {
                var carRentalAvailablityCount = RepositoryFactory.Current.Get<ICarRentalAvailablityCountView>();
                var carRentalAvailablity =
                    carRentalAvailablityCount.GetAll().Where(x => x.CarModelName == modelName).FirstOrDefault();
                if (carRentalAvailablity.CarCount > 0)
                {
                    carModelAvailable = "Available";
                }
                else
                {
                    carModelAvailable = "Not Available";
                }
            }
            else
            {
                var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
                var carrentaldetail =
               carRentalRepository.GetAll()
                   .Where(x => x.CarModel.ModelName == modelName)
                   .FirstOrDefault();
                if (carrentaldetail != null)
                {
                    carModelAvailable = "Available";
                }
                else
                {
                    carModelAvailable = "Not Available";
                }
            }
            return carModelAvailable;
        }

        public void PostCarRental(Contracts.CarRental carRental, string mode)
        {
            if (mode == "Create")
            {
                CarBookingCommand obj = new CarBookingCommand(carRental.RentalId, carRental.CarModelId,
                   carRental.CarRentalEndDate,
                   carRental.CarRentalStartDate, carRental.LocationId, carRental.TotalCost, carRental.DriverName,
                   carRental.LicenseneNumber, carRental.ContactNumber, carRental.EmailId, carRental.Address);
                Channel.Send<CarBookingCommand>(obj);
            }
            else if (mode == "Change")
            {
                CarBookingChangingCommand changingCommand = new CarBookingChangingCommand(carRental.RentalId, carRental.CarRentalEndDate);
                Channel.Send<CarBookingChangingCommand>(changingCommand);
            }
            else if (mode == "Cancel")
            {
                CarBookingCancelingCommand cancelingCommand = new CarBookingCancelingCommand(carRental.RentalId, "Canceled");
                Channel.Send<CarBookingCancelingCommand>(cancelingCommand);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}