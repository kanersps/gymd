using System;
using GymT.Common.Accounts;

namespace GymT.Common.Exercises
{
    public class ExerciseMoveUser
    {
        public Guid Id { get; set; }
        public ExerciseMove ExerciseMove { get; set; }
        public int Amount { get; set; }
        public Account Account { get; set; }
        public int Repetitions { get; set; }
    }
}