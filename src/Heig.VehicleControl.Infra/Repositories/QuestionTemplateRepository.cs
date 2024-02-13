using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using Heig.VehicleControl.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Heig.VehicleControl.Infra.Repositories
{
    public class QuestionTemplateRepository : IQuestionTemplateRepository
    {
        protected readonly VehicleControlContext Db;
        protected readonly DbSet<QuestionTemplate> DbSet;

        public QuestionTemplateRepository(VehicleControlContext context)
        {
            Db = context;
            DbSet = Db.Set<QuestionTemplate>();
        }

        public async Task<IEnumerable<QuestionTemplate>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<QuestionTemplate> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(QuestionTemplate questionTemplate)
        {
            DbSet.Add(questionTemplate);
        }

        public void Remove(QuestionTemplate questionTemplate)
        {
            DbSet.Remove(questionTemplate);
        }

        public void Update(QuestionTemplate questionTemplate)
        {
            DbSet.Update(questionTemplate);
        }
    }
}