using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using Heig.VehicleControl.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Heig.VehicleControl.Infra.Repositories
{
    public class ChecklistRepository : IChecklistRepository
    {
        protected readonly VehicleControlContext Db;
        protected readonly DbSet<Checklist> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public ChecklistRepository(VehicleControlContext context)
        {
            Db = context;
            DbSet = Db.Set<Checklist>();
        }

        public async Task<IEnumerable<Checklist>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Checklist> GetById(Guid id)
        {
            return await DbSet.Include(c => c.Answers).SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        public void Add(Checklist checklist)
        {
            DbSet.Add(checklist);
        }

        public void Remove(Checklist checklist)
        {
            DbSet.Remove(checklist);
        }

        public void Update(Checklist checklist)
        {
            DbSet.Update(checklist);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}