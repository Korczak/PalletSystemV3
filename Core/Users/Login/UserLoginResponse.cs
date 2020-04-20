using Core.Users.Constants;

namespace Core.Users.Login
{
    public class UserLoginResponse
    {
        public UserLoginResult Result { get; }
        public string UserId { get; }
        public string Username { get; }
        public Role Role { get; }
        public bool FirstLogin { get; }

        private UserLoginResponse(UserLoginResult result, string userId = default, string username = default, Role role = default, bool firstLogin = default)
        {
            Result = result;
            Role = role;
            FirstLogin = firstLogin;
        }

        public static UserLoginResponse Successfull(string userId, string username, Role role, bool isFirstLogin) => new UserLoginResponse(UserLoginResult.Success, userId, username, role, isFirstLogin);
        public static UserLoginResponse PasswordOrUsernameError() => new UserLoginResponse(UserLoginResult.PasswordOrUsernameError);
    }
}