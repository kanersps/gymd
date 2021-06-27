using System;
using GymT.Common.Errors;
using GymT.Common.View.Account;
using GymT.Logic;
using Microsoft.AspNetCore.Mvc;

namespace GymT.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost("register")]
        public ActionResult<AccountError> RegisterAccount(RegisterAccount account)
        {
            return _accountService.CreateAccount(account.Nickname, account.Email, account.Password);;
        }
        
        [HttpPost("login")]
        public ActionResult<LoginResponse> LoginAccount(LoginAccount account)
        {
            return _accountService.Login(account.Email, account.Password);
        }
    }
}