using System.Collections.Generic;

namespace GymT.Common.View.Exercises
{
    public class ExerciseViewResponse
    {
        public int PageSize = 10;
        public int Pages { get; set; }
        public List<ExerciseView> Exercises { get; set; }
    }
}