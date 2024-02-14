using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Domain.Interfaces.Repositories
{
    public interface IChecklistRepository : IRepository<Checklist>
    {
        Task<Checklist> GetById(Guid id);

        Task<IEnumerable<Checklist>> GetAll();

        void Add(Checklist checklist);

        void Update(Checklist checklist);

        void Remove(Checklist checklist);
    }
}