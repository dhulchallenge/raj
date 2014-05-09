using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataModel.Infrastucture.Models.Mapping
{
    public class CarRentalAvailablityCountViewMap : EntityTypeConfiguration<CarRentalAvailablityCountView>
    {
        public CarRentalAvailablityCountViewMap()
        {
            // Primary Key
            this.HasKey(t => t.AvailablityId);

            // Properties
            this.Property(t => t.CarModelName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CarRentalAvailablityCountView");
            this.Property(t => t.AvailablityId).HasColumnName("AvailablityId");
            this.Property(t => t.CarModelId).HasColumnName("CarModelId");
            this.Property(t => t.CarModelName).HasColumnName("CarModelName");
            this.Property(t => t.CarCount).HasColumnName("CarCount");
        }
    }
}
