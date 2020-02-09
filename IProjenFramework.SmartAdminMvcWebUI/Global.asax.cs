using FluentValidation.Mvc;
using IProjenFramework.Business.DependencyResolvers.Ninject;
using IProjenFramework.Core.CrossCuttingConcerns.Security.Web;
using IProjenFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using IProjenFramework.Core.Utilities.Mvc.Infrastructure;
using IProjenFramework.MvcWebUI.DependencyResolvers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace IProjenFramework.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine("log4net.config")));
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(
                new BusinessModule(), 
                new DependencyResolverMvc()
           ));
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule());
            });

            #region Data Annotation iptal edlip fluent validation devreye girer.
            ModelValidatorProviders.Providers.Remove(
            ModelValidatorProviders.Providers.OfType<DataAnnotationsModelValidatorProvider>().First());
            #endregion
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }
        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }

                var encTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securityUtlities = new SecurityUtilities();
                var identity = securityUtlities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {

            }


        }
    }
}
