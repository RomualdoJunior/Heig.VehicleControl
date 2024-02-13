using Heig.VehicleControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heig.VehicleControl.Infra.Mappings
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id");

            builder.Property(c => c.Title)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.AdditionalObservation)
                .HasColumnType("varchar(4000)")
                .IsRequired();

            builder.Property(c => c.Ok)
                .IsRequired();

            builder.Ignore(f => f.ValidationResult);
        }
    }
}
