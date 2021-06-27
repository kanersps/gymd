using GymT.Common.Errors;

namespace GymT.Common.View.Account
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public AccountError Error { get; set; }
    }
}