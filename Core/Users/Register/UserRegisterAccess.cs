using Core.Database.Models.Users;
using Core.Database.Settings;
using System.Threading.Tasks;

namespace Core.Users.Register
{
    public class UserRegisterAccess
    {
        public async Task RegisterUser(UserRegistered change)
        {
            using (var handler = new DatabaseHandler())
            {
                await handler.StartTransaction();

                try
                {
                    var user = new User()
                    {
                        Login = change.Username,
                        HashedPassword = change.HashedPassword,
                        Role = change.Role,
                        FirstLogin = true
                    };

                    await handler.db.Users.InsertOneAsync(user);
                    await handler.CommitTransaction();
                }
                catch
                {
                    await handler.AbortTransaction();
                    throw;
                }
            }
        }
    }
}