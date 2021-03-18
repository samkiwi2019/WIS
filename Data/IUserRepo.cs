using System.Threading.Tasks;
using WIS.Models;

namespace WIS.Data
{
    public interface IUserRepo
    {
         Task<User> VerifyUser(string email, string password);

         Task<bool> Create(User user);
         
    }
}