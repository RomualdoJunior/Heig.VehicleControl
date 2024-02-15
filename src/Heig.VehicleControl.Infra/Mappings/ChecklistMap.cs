using Heig.VehicleControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Heig.VehicleControl.Infra.Mappings
{
    public class ChecklistMap : IEntityTypeConfiguration<Checklist>
    {
        public void Configure(EntityTypeBuilder<Checklist> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.OwnerUserId).HasColumnName("OwnerUserId").IsRequired();
            builder.Property(c => c.Status).HasConversion<int>().IsRequired();

            builder.HasOne(e => e.Vehicle)
                   .WithMany(c => c.Checklists);

            builder.HasOne(e => e.OriginalChecklistTemplate)
                   .WithMany(c => c.Checklists);

            builder.HasMany(e => e.Answers)
                    .WithOne(c => c.Checklist);

            builder.Ignore(f => f.ValidationResult);
        }
    }
}
