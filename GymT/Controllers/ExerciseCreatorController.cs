using System;
using System.Collections.Generic;
using GymT.Attributes;
using GymT.Common.View.Exercises;
using GymT.Logic;
using Microsoft.AspNetCore.Mvc;

namespace GymT.Controllers
{
    [Route("api/creator")]
    [ApiController]
    public class ExerciseCreatorController : ControllerBase
    {
        public ExerciseService _ExerciseService;
        
        public ExerciseCreatorController(ExerciseService exerciseService)
        {
            _ExerciseService = exerciseService;
        }
        
        [HttpPost("create")]
        [Authenticated]
        public ActionResult<ExerciseCreationResponse> CreateExercise(ExerciseCreate exerciseCreate)
        {
            Guid id = (Guid) HttpContext.Items["AccountId"];

            if (exerciseCreate.Name.Length <= 0 || exerciseCreate.Moves.Count == 0 || (exerciseCreate.Type != ExerciseCreateType.NoEquipment && exerciseCreate.Equipment.Length == 0))
            {
                return new ExerciseCreationResponse()
                {
                    Success = false,
                    Error = ExerciseCreatorError.InvalidInput
                };
            }
            
            return _ExerciseService.CreateExercise(exerciseCreate, id);
        }

        [HttpPost("search/equipment")]
        [Authenticated]
        public ActionResult<List<string>> FindEquipment(string term)
        {
            return _ExerciseService.FindEquipment(term);
        }
    }
}