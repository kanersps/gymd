using System;
using System.Collections.Generic;
using System.Linq;
using GymT.Common;
using GymT.Common.Accounts;
using GymT.Common.Exercises;
using GymT.Common.View.Exercises;

namespace GymT.Logic
{
    public class ExerciseService
    {
        private IGymTDbContext _GymTDbContext;
        
        public ExerciseService(IGymTDbContext GymTDbContext)
        {
            _GymTDbContext = GymTDbContext;
        }
        public ExerciseCreatorError CreateExercise(ExerciseCreate exerciseCreate, Guid AccountId)
        {
            ExerciseEquipment equipment = null;
            
            Account account = _GymTDbContext.Accounts.FirstOrDefault(_account => _account.Id == AccountId);

            if (exerciseCreate.Type != ExerciseCreateType.NoEquipment)
            {
                equipment = _GymTDbContext.ExerciseEquipment.FirstOrDefault(equipment =>
                    equipment.Name == exerciseCreate.Equipment);

                if (equipment == null)
                {
                    equipment = new ExerciseEquipment()
                    {
                        Name = exerciseCreate.Equipment,
                        Description = "",
                        Type = (ExerciseMoveType) exerciseCreate.Type,
                        Exercise = new List<Exercise>()
                    };

                    _GymTDbContext.ExerciseEquipment.Add(equipment);
                }
            }

            account.CreateExercise(exerciseCreate, equipment);

            _GymTDbContext.SaveChanges();

            return ExerciseCreatorError.NoError;
        }
    }
}