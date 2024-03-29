﻿using Heig.VehicleControl.Domain.Commands.Vehicles.Validation;

namespace Heig.VehicleControl.Domain.Commands.Vehicles
{
    public class UpdateVehicleCommand : VehicleCommand
    {
        public UpdateVehicleCommand(Guid id, string licensePlate, string description)
        {
            Id = id;
            Description = description;
            LicensePlate = licensePlate;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateVehicleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}