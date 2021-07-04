using System;
using GymT.Common.Accounts;

namespace GymT.Common.Exercises
{
    public class CalenderItem
    {
        public Guid Id { get; set; }
        public Account Author { get; set; }
        public Exercise Exercise { get; set; }
        public DateTime Timestamp { get; set; }
    }
}