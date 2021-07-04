using System;
using System.Collections.Generic;
using GymT.Common.Accounts;

namespace GymT.Common.Exercises
{
    public class ExerciseMove
    {
        public Guid Id { get; set; }
        public Exercise Exercise { get; set; }
        public string Instructions { get; set; }
        public string Name { get; set; }
        public int DefaultAmount { get; set; }
        public int DefaultRepetitions { get; set; }
        public ExerciseQuantityType QuantityType { get; set; }
        public List<ExerciseMoveUser> ExerciseMoveUsers { get; set; }
        public int Order { get; set; }
    }
}