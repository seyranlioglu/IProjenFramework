using IProjenFramework.Core.CrossCuttingConcerns.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace IProjenFramework.MvcWebUI.ExtensionMethods
{
    public static class UserIdentityInfo
    {
        private static Identity identity = (Identity)Thread.CurrentPrincipal.Identity;
        public static string FullName
        {
            get
            {
                return identity.FirstName + " " + identity.LastName;
            }
        }
        public static string AuthenticationType
        {
            get
            {
                return identity.AuthenticationType;
            }
        }
        public static bool IsAuthenticated
        {
            get
            {
                return identity.IsAuthenticated;
            }
        }
        public static Guid Id
        {
            get
            {
                return identity.Id;
            }
        }
        public static string Email
        {
            get
            {
                return identity.Email;
            }
        }
        public static List<string> Roles
        {
            get
            {
                return new List<string>(identity.Roles);
            }
        }
        public static List<string> Forms
        {
            get
            {
                return new List<string>(identity.Forms);
            }
        }
        public static int UserId
        {
            get
            {
                return identity.UserId;
            }
        }
        public static List<int> FormIds
        {
            get
            {
                List<string> array = new List<string>(identity.FormIds);
                return new List<int>(array.ConvertAll(s => int.Parse(s)));
            }
        }
    }
}