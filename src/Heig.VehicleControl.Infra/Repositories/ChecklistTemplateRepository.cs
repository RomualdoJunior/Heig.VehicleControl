using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using Heig.VehicleControl.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Heig.VehicleControl.Infra.Repositories
{
    public class ChecklistTemplateRepository : IChecklistTemplateRepository
    {
        protected readonly VehicleControlContext Db;
        protected readonly DbSet<ChecklistTemplate> DbSet;

        public ChecklistTemplateRepository(VehicleControlContext context)
        {
            Db = context;
            DbSet = Db.Set<ChecklistTemplate>();
        }

        public async Task<IEnumerable<ChecklistTemplate>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ChecklistTemplate> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(ChecklistTemplate checklistTemplate)
        {
            DbSet.Add(checklistTemplate);
        }

        public void Remove(ChecklistTemplate checklistTemplate)
        {
            DbSet.Remove(checklistTemplate);
        }

        public void Update(ChecklistTemplate checklistTemplate)
        {
            DbSet.Update(checklistTemplate);
        }
    }
}