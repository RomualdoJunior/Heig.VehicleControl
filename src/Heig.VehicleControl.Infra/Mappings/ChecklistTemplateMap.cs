using Heig.VehicleControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heig.VehicleControl.Infra.Mappings
{
    public class ChecklistTemplateMap : IEntityTypeConfiguration<ChecklistTemplate>
    {
        public void Configure(EntityTypeBuilder<ChecklistTemplate> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id");

            builder.Property(c => c.Title)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(c => c.Number)
                .HasColumnName("Number")
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasMany(c => c.Questions)
                .WithOne(c => c.ChecklistTemplate)
                .IsRequired();

            builder.Ignore(f => f.ValidationResult);
        }
    }
}
