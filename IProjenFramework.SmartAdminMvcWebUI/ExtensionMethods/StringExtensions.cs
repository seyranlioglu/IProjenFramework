using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string UnDash(this object value)
        {
            return ((value as string) ?? string.Empty).UnDash();
        }

        public static string UnDash(this string value)
        {
            return (value ?? string.Empty)
                .Replace("-", string.Empty)
                .Replace("Browse","List")
                .Replace("New","List");
        }
    }
}