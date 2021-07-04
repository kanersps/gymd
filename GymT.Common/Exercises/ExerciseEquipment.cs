using System;
using System.Collections.Generic;

namespace GymT.Common.Exercises
{
    public class ExerciseEquipment
    {
        public Guid Id { get; set; }
        public List<Exercise> Exercise { get; set; }
        public ExerciseMoveType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}