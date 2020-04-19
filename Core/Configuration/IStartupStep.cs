namespace Core.Configuration
{
    public interface IStartupStep
    {
        IStartupValidation Configure();
    }
}
