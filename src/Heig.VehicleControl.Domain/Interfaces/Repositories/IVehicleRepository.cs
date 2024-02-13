using Heig.VehicleControl.Domain.Common;
using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<Vehicle> GetById(Guid id);

        Task<Vehicle> GetByLicensePlate(string licensePlate);

        Task<IEnumerable<Vehicle>> GetAll();

        void Add(Vehicle vehicle);

        void Update(Vehicle vehicle);

        void Remove(Vehicle vehicle);
    }
}