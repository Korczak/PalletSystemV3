using Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Configuration
{
    public class WebStartupValidation : IStartupValidation
    {
        public string DisplayName => "Web Service Settings";
        public bool Success => true;

        public IEnumerable<string> GetErrors() => Array.Empty<string>();
    }
}
