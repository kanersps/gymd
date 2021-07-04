using GymT.Common;
using GymT.Common.Accounts;
using GymT.Common.Exercises;
using Microsoft.EntityFrameworkCore;

namespace GymT.Data
{
    public class GymTDbContext : DbContext, IGymTDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseEquipment> ExerciseEquipment { get; set; }

        public GymTDbContext(DbContextOptions<GymTDbContext> options) : base(options)
        {
            
        }
    }
}