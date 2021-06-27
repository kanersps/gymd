using System.Linq;
using GymT.Common;
using GymT.Common.Accounts;
using GymT.Common.Errors;
using GymT.Common.View.Account;

namespace GymT.Logic
{
    public class AccountService
    {
        private IGymTDbContext _context;
        
        public AccountService(IGymTDbContext context)
        {
            _context = context;
        }

        public AccountError IsNicknameInUse(string nickname)
        {
            if (_context.Accounts.FirstOrDefault(account => account.Nickname == nickname) != null)
            {
                return AccountError.NicknameInUse;
            }

            return AccountError.NoError;
        }

        public AccountError IsEmailInUse(string email)
        {
            if (_context.Accounts.FirstOrDefault(account => account.Email == email) != null)
            {
                return AccountError.EmailInUse;
            }

            return AccountError.NoError;
        }

        public LoginResponse Login(string email, string password)
        {
            Account account = _context.Accounts.FirstOrDefault(account => account.Email == email);

            if (account == null)
            {
                return new LoginResponse()
                {
                    Success = false,
                    Error = AccountError.UnknownAccount
                };
            }

            if (account.Password != password)
            {
                return new LoginResponse()
                {
                    Success = false,
                    Error = AccountError.UnknownAccount
                };
            }

            return new LoginResponse()
            {
                Success = true,
                Error = AccountError.NoError,
                Token = account.GenerateToken()
            };
        }

        public AccountError CreateAccount(string nickname, string email, string password)
        {
            AccountError nicknameInUse = IsNicknameInUse(nickname);

            if (nicknameInUse != AccountError.NoError)
            {
                return nicknameInUse;
            }

            AccountError emailInUse = IsEmailInUse(email);

            if (emailInUse != AccountError.NoError)
            {
                return emailInUse;
            }
            
            _context.Accounts.Add(new Account
            {
                Nickname = nickname,
                Email = email,
                Password = password
            });

            _context.SaveChanges();

            return AccountError.NoError;
        }
    }
}