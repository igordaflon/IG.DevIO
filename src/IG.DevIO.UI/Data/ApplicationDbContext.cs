using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IG.DevIO.UI.ViewModels;

namespace IG.DevIO.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IG.DevIO.UI.ViewModels.ProductViewModel> ProductViewModel { get; set; }
    }
}