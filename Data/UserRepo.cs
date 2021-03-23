using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WIS.Models;
using WIS.Utils;

namespace WIS.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly MyContext _ctx;

        public UserRepo(MyContext context)
        {
            _ctx = context;
        }

        public async Task<User> VerifyUser(string email, string password)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Email.Equals(email) || x.Nickname.Equals(email));
            var isPasswordMatched = Extensions.VerifyPassword(password, user.HashPassword, user.Salt);
            return isPasswordMatched ? user : null;
        }

        public async Task<bool> Create(User user)
        {
            await _ctx.Users.AddAsync(user);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}