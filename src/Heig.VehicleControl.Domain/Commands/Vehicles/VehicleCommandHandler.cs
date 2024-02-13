using FluentValidation.Results;
using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;

namespace Heig.VehicleControl.Domain.Commands.Vehicles
{
    public class VehicleCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewVehicleCommand, ValidationResult>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewVehicleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var vehicle = new Vehicle(request.Description, request.LicensePlate);

            if (await _vehicleRepository.GetByLicensePlate(vehicle.LicensePlate) != null)
            {
                AddError("This license plate is already been used.");
                return ValidationResult;
            }

            _vehicleRepository.Add(vehicle);

            return await Commit(_vehicleRepository.UnitOfWork);
        }
    }
}