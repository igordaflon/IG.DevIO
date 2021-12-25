using Models;

namespace Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierAddress(Guid Id);
        Task<Supplier> GetSupplierProductAddress(Guid Id);
    }
}
