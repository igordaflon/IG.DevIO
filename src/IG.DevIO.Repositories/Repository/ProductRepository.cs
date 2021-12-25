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
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(DevIODbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await Search(p => p.SupplierId == supplierId);
        }

        public async Task<IEnumerable<Product>> GetProductsSuppliers()
        {
            return await db.Products.AsNoTracking().Include(s => s.Supplier).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product> GetProductSupplier(Guid id)
        {
            return await db.Products.AsNoTracking().Include(s => s.Supplier).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
