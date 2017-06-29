using MehsBugsWebApp.Models;
using MehsCoreCommon.Security.Core;
using Newtonsoft.Json;
using System;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MehsBugsWebApp.Managers
{
    public class UserManager
    {
        public static ModLogin User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return ((MehsPrincipal)(HttpContext.Current.User)).User;
                }
                else if (HttpContext.Current.Items.Contains("User"))
                {
                    return (ModLogin)HttpContext.Current.Items["User"];
                }
                else
                {
                    return null;
                }
            }
        }

        public static string PathServer { get; set; }

        public static ModLogin AuthenticateUser(string username, string password)
        {
            ILoginUser login = IoCConfig.Contenedor.Resolve<ILoginUser>("LoginUser");
            var result = login.Login(username, password);
            ModLogin mod = new ModLogin()
            {
                Id = result.Id,
                Mail = result.Email,
                UserName = result.UserName,
                UserPassword = result.Password
            };
            return mod;
        }

        public static bool ValidateUser(ModLogin login, HttpResponseBase response)
        {
            bool result = false;
            if (Membership.ValidateUser(login.Mail, login.UserPassword))
            {
                string userData = JsonConvert.SerializeObject(User);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1
                                                       , login.Mail
                                                       , DateTime.Now
                                                       , DateTime.Now.AddDays(30)
                                                       , true
                                                       , userData
                                                       , FormsAuthentication.FormsCookiePath);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                result = true;
            }
            return result;
        }

        public static void Logoff(HttpSessionStateBase session, HttpResponseBase response)
        {
            session.Abandon();
            FormsAuthentication.SignOut();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            response.Cookies.Add(cookie);
        }
    }
}