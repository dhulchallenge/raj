using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataModel.Infrastucture.Models.Mapping
{
    public class PreferredCarModelViewMap : EntityTypeConfiguration<PreferredCarModelView>
    {
        public PreferredCarModelViewMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CarModelName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PreferredCarModelView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CarModelId).HasColumnName("CarModelId");
            this.Property(t => t.CarModelName).HasColumnName("CarModelName");
            this.Property(t => t.RentedCount).HasColumnName("RentedCount");
        }
    }
}
