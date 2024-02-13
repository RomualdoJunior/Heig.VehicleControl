using FluentValidation.Results;
using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;

namespace Heig.VehicleControl.Domain.Commands.Vehicles
{
    public class VehicleCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewVehicleCommand, ValidationResult>,
        IRequestHandler<UpdateVehicleCommand, ValidationResult>,
        IRequestHandler<RemoveVehicleCommand, ValidationResult>
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

        public async Task<ValidationResult> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var vehicle = new Vehicle(request.Description, request.LicensePlate);
            var existingVehicle = await _vehicleRepository.GetByLicensePlate(vehicle.LicensePlate);

            if (existingVehicle != null && existingVehicle.Id != vehicle.Id)
            {
                if (!existingVehicle.LicensePlate.Equals(vehicle.LicensePlate))
                {
                    AddError("This license plate is already been used.");
                    return ValidationResult;
                }
            }

            _vehicleRepository.Update(vehicle);

            return await Commit(_vehicleRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveVehicleCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var vehicle = await _vehicleRepository.GetById(request.Id);

            if (vehicle is null)
            {
                AddError("The vehicle doesn't exists.");
                return ValidationResult;
            }

            _vehicleRepository.Remove(vehicle);

            return await Commit(_vehicleRepository.UnitOfWork);
        }
    }
}