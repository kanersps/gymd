using GymT.Common;
using GymT.Common.Accounts;
using Microsoft.EntityFrameworkCore;

namespace GymT.Data
{
    public class GymDbContext : DbContext, IGymDbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
            
        }
    }
}