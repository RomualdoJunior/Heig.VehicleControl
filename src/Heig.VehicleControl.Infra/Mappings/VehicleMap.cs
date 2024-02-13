using Heig.VehicleControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heig.VehicleControl.Infra.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id");

            builder.Property(c => c.Description)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(c => c.LicensePlate)
                .HasColumnType("varchar(7)")
                .IsRequired();

            builder.Ignore(f => f.ValidationResult);
        }
    }
}
