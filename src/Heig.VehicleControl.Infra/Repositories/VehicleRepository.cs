using Heig.VehicleControl.Domain.Entities;
using Heig.VehicleControl.Domain.Interfaces;
using Heig.VehicleControl.Domain.Interfaces.Repositories;
using Heig.VehicleControl.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Heig.VehicleControl.Infra.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        protected readonly VehicleControlContext Db;
        protected readonly DbSet<Vehicle> DbSet;

        public VehicleRepository(VehicleControlContext context)
        {
            Db = context;
            DbSet = Db.Set<Vehicle>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Vehicle> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(Vehicle vehicle)
        {
            DbSet.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            DbSet.Remove(vehicle);
        }

        public void Update(Vehicle vehicle)
        {
            DbSet.Update(vehicle);
        }

        public async Task<Vehicle> GetByLicensePlate(string licensePlate)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.LicensePlate == licensePlate);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}