using System;

namespace MehsBugsWebApp.Models
{
    public class ModLogin
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Mail { get; set; }
        public string RedirectUrl { get; set; }

        public ModLogin()
        {

        }
    }
}