using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarRental.DataModel.Infrastucture.Models.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => t.CityId);

            // Properties
            this.Property(t => t.CityName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("City");
            this.Property(t => t.CityId).HasColumnName("CityId");
            this.Property(t => t.CityName).HasColumnName("CityName");
        }
    }
}
