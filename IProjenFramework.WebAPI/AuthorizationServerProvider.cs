using IProjenFramework.Business.Abstract;
using IProjenFramework.Business.Concrete;
using IProjenFramework.Business.DependencyResolvers.Ninject;
using IProjenFramework.DataAccess.Abstract;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace IProjenFramework.WebAPI
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //private readonly UserManager _userService;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var memberService = InstanceFactory.GetInstance<IUserDal>();
            UserManager _userService = new UserManager(memberService);
            if (_userService.IsUserAndPassword(context.UserName, context.Password))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                var user = _userService.GetByUserNameOrEmailAndPassword(context.UserName, context.Password);
                identity.AddClaim(new Claim("UserName", user.Name + " " + user.Surname));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Oturum Hatası", "Kullanıcı adı ve şifre hatalıdır");
            }
        }
    }
}