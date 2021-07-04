using System.Collections.Generic;

namespace GymT.Common.View.Exercises
{
    public class ExerciseCreate
    {
        public string Name { get; set; }
        public ExerciseCreateType Type { get; set; }
        public string Equipment { get; set; }
        public List<ExerciseMoveCreate> Moves { get; set; }
    }
}