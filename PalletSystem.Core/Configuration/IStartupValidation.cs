using System.Collections.Generic;

namespace PalletSystem.Core.Configuration
{
    public interface IStartupValidation
    {
        string  DisplayName { get; }
        bool Success { get; }
        IEnumerable<string> GetErrors();
    }
}
