using GymT.Common.Accounts;
using Microsoft.EntityFrameworkCore;

namespace GymT.Common
{
    public interface IGymDbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}