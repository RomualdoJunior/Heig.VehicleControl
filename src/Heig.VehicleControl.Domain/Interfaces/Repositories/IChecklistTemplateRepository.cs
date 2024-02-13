using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Domain.Interfaces.Repositories
{
    public interface IChecklistTemplateRepository
    {
        Task<ChecklistTemplate> GetById(Guid id);

        Task<IEnumerable<ChecklistTemplate>> GetAll();

        void Add(ChecklistTemplate checklistTemplate);

        void Update(ChecklistTemplate checklistTemplate);

        void Remove(ChecklistTemplate checklistTemplate);
    }
}