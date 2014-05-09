using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CarRental.DataModel.Infrastucture.Models.Mapping;

namespace CarRental.DataModel.Infrastucture.Models
{
    public partial class CarRentalDatabaseContext : DbContext
    {
        static CarRentalDatabaseContext()
        {
            Database.SetInitializer<CarRentalDatabaseContext>(null);
        }

        public CarRentalDatabaseContext()
            : base("Name=CarRentalDatabaseContext")
        {
        }

        public DbSet<CarManufacturerDetail> CarManufacturerDetails { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarRentalAvailablityCountView> CarRentalAvailablityCountViews { get; set; }
        public DbSet<CarRentalAvailablityView> CarRentalAvailablityViews { get; set; }
        public DbSet<CarRentalDetail> CarRentalDetails { get; set; }
        public DbSet<CarRentalDetailsHistory> CarRentalDetailsHistories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LeastExpenseCarModelView> LeastExpenseCarModelViews { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PreferredCarModelView> PreferredCarModelViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarManufacturerDetailMap());
            modelBuilder.Configurations.Add(new CarModelMap());
            modelBuilder.Configurations.Add(new CarRentalAvailablityCountViewMap());
            modelBuilder.Configurations.Add(new CarRentalAvailablityViewMap());
            modelBuilder.Configurations.Add(new CarRentalDetailMap());
            modelBuilder.Configurations.Add(new CarRentalDetailsHistoryMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new LeastExpenseCarModelViewMap());
            modelBuilder.Configurations.Add(new LocationMap());
            modelBuilder.Configurations.Add(new PreferredCarModelViewMap());
        }
    }
}
