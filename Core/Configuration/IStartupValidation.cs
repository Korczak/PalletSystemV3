using System.Collections.Generic;

namespace Core.Configuration
{
    public interface IStartupValidation
    {
        string  DisplayName { get; }
        bool Success { get; }
        IEnumerable<string> GetErrors();
    }
}
