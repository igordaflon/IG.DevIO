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
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DevIODbContext context) : base(context){}

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await db.Addresses.AsNoTracking().FirstOrDefaultAsync(f => f.SupplierId == supplierId);
        }
    }
}
