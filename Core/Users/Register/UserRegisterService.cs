using Core.Users.Common;
using System.Threading.Tasks;

namespace Core.Users.Register
{
    public class UserRegisterService
    {
        private readonly UserRegisterAccess _access;
        private readonly PasswordHashGenerator _hashGenerator;
        private readonly RandomPasswordGenerator _passwordGenerator;

        public UserRegisterService(UserRegisterAccess access, PasswordHashGenerator hashGenerator, RandomPasswordGenerator passwordGenerator)
        {
            _access = access;
            _hashGenerator = hashGenerator;
            _passwordGenerator = passwordGenerator;
        }

        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest input, BasicUserData registeringUser)
        {
            string randomPassword = _passwordGenerator.GenerateRandomPassword(12);

            var hashedPassword = _hashGenerator.HashPassword(randomPassword);

            var change = new UserRegistered(input.Username, hashedPassword, input.Role, registeringUser);

            await _access.RegisterUser(change);
            return new UserRegisterResponse(UserRegisterStatus.Success, input.Username, randomPassword);
        }
    }
}
