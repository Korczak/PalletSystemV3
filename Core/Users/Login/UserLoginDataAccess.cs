using Core.Database.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace Core.Users.Login
{
    public class UserLoginDataAccess
    {
        public async Task<UserLoginFoundUser> FindUser(string username)
        {
            using (var handler = new DatabaseHandler())
            {
                var foundUser = await handler.db.Users.AsQueryable()
                    .Where(u => !u.Deleted && !u.Deleted && u.Login == username)
                    .Select(u => new UserLoginFoundUser(u.Id.ToString(), u.Login, u.HashedPassword, u.Role, u.FirstLogin))
                    .FirstOrDefaultAsync();

                return foundUser;
            }
        }
    }
}