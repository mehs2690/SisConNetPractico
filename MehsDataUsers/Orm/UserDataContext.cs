using MehsDataUsers.Pocos;
using System.Configuration;
using System.Data.Entity;

namespace MehsDataUsers.Orm
{
    public class UserDataContext : DbContext
    {
        public UserDataContext() : base(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["OriginData"].ToString()].ToString())
        {

        }

        public UserDataContext(string connection) : base(connection)
        {

        }

        public DbSet<UserPoco> Users { get; set; }
        public DbSet<ProfilePoco> Profiles { get; set; }
        public DbSet<ApplicationPoco> Applications { get; set; }
        public DbSet<UserCatalogPoco> UserTypes { get; set; }
        public DbSet<MenuPoco> Options { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
