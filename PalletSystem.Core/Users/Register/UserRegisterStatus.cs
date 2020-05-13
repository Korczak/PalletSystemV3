namespace PalletSystem.Core.Users.Register
{
    public enum UserRegisterStatus
    {
        Success,
        UserExists,
        UsernameIsEmpty,
        UsernameContainsWhitespace
    }
}
