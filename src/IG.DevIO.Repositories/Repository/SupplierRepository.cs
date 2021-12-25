using Context;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DevIODbContext context) : base(context) { }

        public async Task<Supplier> GetSupplierAddress(Guid Id)
        {
            return await db.Suppliers.AsNoTracking().Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Supplier> GetSupplierProductAddress(Guid Id)
        {
            return await db.Suppliers.AsNoTracking().Include(c => c.Products).Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
