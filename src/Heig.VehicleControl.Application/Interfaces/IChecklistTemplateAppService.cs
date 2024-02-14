using FluentValidation.Results;
using Heig.VehicleControl.Application.ViewModels;

namespace Heig.VehicleControl.Application.Interfaces
{
    public interface IChecklistTemplateAppService : IDisposable
    {
        Task<IEnumerable<ChecklistTemplateViewModel>> GetAll();

        Task<ChecklistTemplateViewModel> GetById(Guid id);

        Task<ValidationResult> Register(ChecklistTemplateViewModel vehicleViewModel);

        Task<ValidationResult> Update(ChecklistTemplateViewModel vehicleViewModel);

        Task<ValidationResult> Remove(Guid id);
    }
}