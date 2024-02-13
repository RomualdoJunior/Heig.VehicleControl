using FluentValidation.Results;
using Heig.VehicleControl.Application.ViewModels;

namespace Heig.VehicleControl.Application.Interfaces
{
    public interface IVehicleAppService : IDisposable
    {
        Task<IEnumerable<VehicleViewModel>> GetAll();

        Task<VehicleViewModel> GetById(Guid id);

        Task<ValidationResult> Register(VehicleViewModel vehicleViewModel);

        Task<ValidationResult> Update(VehicleViewModel vehicleViewModel);

        Task<ValidationResult> Remove(Guid id);
    }
}