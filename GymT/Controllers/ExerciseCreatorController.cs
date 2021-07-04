using System;
using GymT.Attributes;
using GymT.Common.View.Exercises;
using GymT.Logic;
using Microsoft.AspNetCore.Mvc;

namespace GymT.Controllers
{
    [Route("api/exercise/creator")]
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
        public ActionResult<ExerciseCreatorError> CreateExercise(ExerciseCreate exerciseCreate)
        {
            Guid id = (Guid) HttpContext.Items["AccountId"];

            return _ExerciseService.CreateExercise(exerciseCreate, id);
        }
    }
}