using Heig.VehicleControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heig.VehicleControl.Infra.Mappings
{
    public class QuestionTemplateMap : IEntityTypeConfiguration<QuestionTemplate>
    {
        public void Configure(EntityTypeBuilder<QuestionTemplate> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id");

            builder.Property(c => c.Title)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(c => c.FullDescription)
                .HasColumnType("varchar(2000)")
                .IsRequired();

            builder.Ignore(f => f.ValidationResult);
        }
    }
}
