using GymT.Common.Exercises;

namespace GymT.Common.View.Exercises
{
    public class ExerciseMoveCreate
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public ExerciseQuantityType QuantityType { get; set; }
        public int DefaultAmount { get; set; }
        public int DefaultRepetitions { get; set; }
    }
}