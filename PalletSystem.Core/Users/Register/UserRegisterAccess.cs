using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using PalletSystem.Core.Database.Models.User;
using PalletSystem.Core.Database.Settings;

namespace PalletSystem.Core.Users.Register
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
                    var user = new Database.Models.User.Users()
                    {
                        Name = change.Username,
                        Password = change.HashedPassword,
                        Role = Constants.Role.User
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