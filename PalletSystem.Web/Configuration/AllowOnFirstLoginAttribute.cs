﻿using System;

namespace PalletSystem.Web.Configuration
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AllowOnFirstLoginAttribute : Attribute
    {
    }
}