using Core.Users.Constants;

namespace Core.Users.Login
{
    public class UserLoginFoundUser
    {
        public string Id { get; }
        public string Username { get; }
        public string HashedPassword { get; }
        public Role Role { get; }
        public bool FirstLogin { get; }

        public UserLoginFoundUser(string id, string username, string hashedPassword, Role role, bool firstLogin)
        {
            Id = id;
            Username = username;
            HashedPassword = hashedPassword;
            Role = role;
            FirstLogin = firstLogin;
        }
    }
}