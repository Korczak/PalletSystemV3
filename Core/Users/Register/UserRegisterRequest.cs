using Core.Users.Constants;

namespace Core.Users.Register
{
    public class UserRegisterRequest
    {
        public string Username { get; }
        public Role Role { get; }

        public UserRegisterRequest(string username, Role role)
        {
            Username = username;
            Role = role;
        }
    }
}