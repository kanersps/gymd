using System;

namespace GymT.Common.View.Exercises
{
    public class ExerciseViewRequest
    {
        public DateTime LastView { get; set; }
        public bool NextPage { get; set; }
    }
}