using System;
using System.Collections.Generic;
using GymT.Common.Accounts;

namespace GymT.Common.Exercises
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public Account Author { get; set; }
        public string Name { get; set; }
        public ExerciseEquipment Equipment { get; set; }
        public List<ExerciseMove> Moves { get; set; }
        public DateTime Created { get; set; }
    }
}