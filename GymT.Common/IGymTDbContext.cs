using GymT.Common.Accounts;
using Microsoft.EntityFrameworkCore;

namespace GymT.Common
{
    public interface IGymTDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public int SaveChanges();
    }
}