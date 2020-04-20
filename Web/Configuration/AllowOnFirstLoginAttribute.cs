using System;

namespace Web.Configuration
{
    /// <summary>
    /// Allows using a controller action before initial password change
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AllowOnFirstLoginAttribute : Attribute
    {
    }
}
