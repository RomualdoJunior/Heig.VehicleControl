using Heig.VehicleControl.Domain.Interfaces;

namespace Heig.VehicleControl.Domain.Common
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}