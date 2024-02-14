using AutoMapper;
using FluentValidation.Results;
using Heig.VehicleControl.Application.Interfaces;
using Heig.VehicleControl.Application.ViewModels;
using Heig.VehicleControl.Domain.Commands.Vehicles;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using MediatR;

namespace Heig.VehicleControl.Application.Services
{
    internal class VehicleAppService : IVehicleAppService
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMediator _mediator;

        public VehicleAppService(IMapper mapper, IVehicleRepository vehicleRepository, IMediator mediator)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<VehicleViewModel>>(await _vehicleRepository.GetAll());
        }

        public async Task<VehicleViewModel> GetById(Guid id)
        {
            return _mapper.Map<VehicleViewModel>(await _vehicleRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(VehicleViewModel viewModel)
        {
            var registerCommand = new RegisterNewVehicleCommand(viewModel.LicensePlate, viewModel.Description);
            return await _mediator.Send(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveVehicleCommand(id);
            return await _mediator.Send(removeCommand);
        }

        public async Task<ValidationResult> Update(VehicleViewModel viewModel)
        {
            var updateCommand = new UpdateVehicleCommand(viewModel.Id, viewModel.LicensePlate, viewModel.Description);

            return await _mediator.Send(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}