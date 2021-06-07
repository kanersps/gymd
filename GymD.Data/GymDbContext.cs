using GymD.Common;
using GymD.Common.Accounts;
using Microsoft.EntityFrameworkCore;

namespace GymD.Data
{
    public class GymDbContext : DbContext, IGymDbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}