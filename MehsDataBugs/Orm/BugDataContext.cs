using MehsDataBugs.Pocos;
using System.Configuration;
using System.Data.Entity;

namespace MehsDataBugs.Orm
{
    public class BugDataContext : DbContext
    {
        public BugDataContext() : base(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["OriginData"].ToString()].ToString())
        {

        }

        public BugDataContext(string connection) : base(connection)
        {

        }

        public DbSet<BugPoco> Bugs { get; set; }
        public DbSet<BugNotificationPoco> Notifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
