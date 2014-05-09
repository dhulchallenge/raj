using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataModel.Infrastucture.Models.Mapping
{
    public class LeastExpenseCarModelViewMap : EntityTypeConfiguration<LeastExpenseCarModelView>
    {
        public LeastExpenseCarModelViewMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CarModelName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("LeastExpenseCarModelView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RentalId).HasColumnName("RentalId");
            this.Property(t => t.CarModelId).HasColumnName("CarModelId");
            this.Property(t => t.CarModelName).HasColumnName("CarModelName");
            this.Property(t => t.Cost).HasColumnName("Cost");
        }
    }
}
