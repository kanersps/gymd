using GymD.Common.Accounts;
using Microsoft.EntityFrameworkCore;

namespace GymD.Common
{
    public interface IGymDbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}