using GymT.Common;
using GymT.Common.Accounts;

namespace GymT.Logic
{
    public class AccountService
    {
        private IGymDbContext _context;
        
        public AccountService(IGymDbContext context)
        {
            _context = context;
        }

        public void CreateAccount(string email, string password)
        {
            _context.Accounts.Add(new ()
            {
                Email = email,
                Password = password
            });
        }
    }
}