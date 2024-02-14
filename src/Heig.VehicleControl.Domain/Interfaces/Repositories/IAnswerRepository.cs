using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Domain.Interfaces.Repositories
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<Answer> GetById(Guid id);

        Task<IEnumerable<Answer>> GetAll();

        void Add(Answer answer);

        void Update(Answer answer);

        void Remove(Answer answer);
    }
}