using System.Threading.Tasks;
using Sodium;


namespace Core.Users.Login
{
    public class UserLoginService
    {
        private readonly UserLoginDataAccess _access;

        public UserLoginService(UserLoginDataAccess access)
        {
            _access = access;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var foundUser = await _access.FindUser(request.Username);

            if (foundUser == null)
            {
                return UserLoginResponse.PasswordOrUsernameError();
            }

            if (PasswordHash.ArgonHashStringVerify(foundUser.HashedPassword, request.Password))
            {
                return UserLoginResponse.Successfull(foundUser.Id, foundUser.Username, foundUser.Role, foundUser.FirstLogin);
            }

            return UserLoginResponse.PasswordOrUsernameError();
        }
    }
}
