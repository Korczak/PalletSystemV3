using Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Logging
{
    public class LoggingValidation : IStartupValidation
    {
        public string DisplayName { get; } = "Logging";
        public bool Success => true;
        public IEnumerable<string> GetErrors() => Array.Empty<string>();
    }
}
