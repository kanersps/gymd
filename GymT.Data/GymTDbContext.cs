using GymT.Common;
using GymT.Common.Accounts;
using Microsoft.EntityFrameworkCore;

namespace GymT.Data
{
    public class GymTDbContext : DbContext, IGymTDbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public GymTDbContext(DbContextOptions<GymTDbContext> options) : base(options)
        {
            
        }
    }
}