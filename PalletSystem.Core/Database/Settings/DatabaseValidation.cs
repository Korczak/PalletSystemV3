﻿using System;
using System.Collections.Generic;
using PalletSystem.Core.Configuration;

namespace PalletSystem.Core.Database.Settings
{
    public class DatabaseValidation : IStartupValidation
    {
        public string DisplayName => "Database Service";
        public bool Success { get; }
        public IEnumerable<string> GetErrors() => Array.Empty<string>();

        private DatabaseValidation(bool success)
        {
            Success = success;
        }

        public static DatabaseValidation Successfull() => new DatabaseValidation(true);
        public static DatabaseValidation Failure() => new DatabaseValidation(false);


    }
}
