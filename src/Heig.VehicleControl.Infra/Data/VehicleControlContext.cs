using FluentValidation.Results;
using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces;
using Heig.VehicleControl.Infra.Mappings;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Heig.VehicleControl.Infra.Data
{
    public sealed class VehicleControlContext : DbContext, IUnitOfWork
    {
        public VehicleControlContext(DbContextOptions<VehicleControlContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ChecklistTemplate> ChecklistTemplates { get; set; }
        public DbSet<QuestionTemplate> QuestionTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new ChecklistMap());
            modelBuilder.ApplyConfiguration(new AnswerMap());
            modelBuilder.ApplyConfiguration(new ChecklistTemplateMap());
            modelBuilder.ApplyConfiguration(new QuestionTemplateMap());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}