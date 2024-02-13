using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using Heig.VehicleControl.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Heig.VehicleControl.Infra.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        protected readonly VehicleControlContext Db;
        protected readonly DbSet<Answer> DbSet;

        public AnswerRepository(VehicleControlContext context)
        {
            Db = context;
            DbSet = Db.Set<Answer>();
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Answer> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(Answer answer)
        {
            DbSet.Add(answer);
        }

        public void Remove(Answer answer)
        {
            DbSet.Remove(answer);
        }

        public void Update(Answer answer)
        {
            DbSet.Update(answer);
        }
    }
}