using System;
using System.Collections.Generic;
using GymT.Attributes;
using GymT.Common.View.Exercises;
using GymT.Logic;
using Microsoft.AspNetCore.Mvc;

namespace GymT.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly AccountService _accountService;
        public ExerciseController(AccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost("exercises")]
        [Authenticated]
        public ActionResult<ExerciseViewResponse> RegisterAccount(ExerciseViewRequest request)
        {
            Guid id = (Guid) HttpContext.Items["AccountId"];
            
            return _accountService.GetUserExercises(id, request);
        }
        
    }
}