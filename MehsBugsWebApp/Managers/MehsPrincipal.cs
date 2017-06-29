using MehsBugsWebApp.Models;
using System.Security.Principal;

namespace MehsBugsWebApp.Managers
{
    public class MehsPrincipal : IPrincipal
    {
        public MehsPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public IIdentity Identity { get; private set; }

        public ModLogin User { get; set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}