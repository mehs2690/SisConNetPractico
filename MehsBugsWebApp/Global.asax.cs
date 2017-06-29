using MehsBugsWebApp.Managers;
using MehsBugsWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MehsBugsWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            IoCConfig.InitDependencies();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                var principal = new MehsPrincipal(identity);

                string userData = ((FormsIdentity)(Context.User.Identity)).Ticket.UserData;
                principal.User = JsonConvert.DeserializeObject<ModLogin>(userData);
                Context.User = principal;
            }
        }
    }
}
