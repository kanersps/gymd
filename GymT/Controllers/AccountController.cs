using System;
using GymT.Common.View.Account;
using Microsoft.AspNetCore.Mvc;

namespace GymT.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("register")]
        public ActionResult RegisterAccount(RegisterAccount account)
        {
            Console.WriteLine(account.Email);
            Console.WriteLine(account.Password);
            return new OkResult();
        }
    }
}