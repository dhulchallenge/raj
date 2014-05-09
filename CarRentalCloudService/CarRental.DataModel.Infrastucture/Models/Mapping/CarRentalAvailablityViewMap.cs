using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataModel.Infrastucture.Models.Mapping
{
    public class CarRentalAvailablityViewMap : EntityTypeConfiguration<CarRentalAvailablityView>
    {
        public CarRentalAvailablityViewMap()
        {
            // Primary Key
            this.HasKey(t => t.AvailablityId);

            // Properties
            this.Property(t => t.CarModelName)
                .HasMaxLength(100);

            this.Property(t => t.LicenseneNumber)
                .HasMaxLength(50);

            this.Property(t => t.EmailId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CarRentalAvailablityView");
            this.Property(t => t.AvailablityId).HasColumnName("AvailablityId");
            this.Property(t => t.RentalId).HasColumnName("RentalId");
            this.Property(t => t.CarModelId).HasColumnName("CarModelId");
            this.Property(t => t.CarModelName).HasColumnName("CarModelName");
            this.Property(t => t.CarRentalStartDate).HasColumnName("CarRentalStartDate");
            this.Property(t => t.CarRentalEndDate).HasColumnName("CarRentalEndDate");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.LicenseneNumber).HasColumnName("LicenseneNumber");
            this.Property(t => t.ContactNumber).HasColumnName("ContactNumber");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
        }
    }
}
