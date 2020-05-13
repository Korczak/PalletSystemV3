
using PalletSystem.Core.Users.Constants;

namespace PalletSystem.Core.Users.Register
{
    public class UserRegisterRequest
    {
        public string Username { get; }
        public string Password { get; }

        public UserRegisterRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}