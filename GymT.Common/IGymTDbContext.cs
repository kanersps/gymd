using GymT.Common.Accounts;
using GymT.Common.Exercises;
using Microsoft.EntityFrameworkCore;

namespace GymT.Common
{
    public interface IGymTDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseEquipment> ExerciseEquipment { get; set; }
        public int SaveChanges();
    }
}