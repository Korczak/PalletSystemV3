namespace PalletSystem.Core.Configuration
{
    public interface IStartupStep
    {
        IStartupValidation Configure();
    }
}
