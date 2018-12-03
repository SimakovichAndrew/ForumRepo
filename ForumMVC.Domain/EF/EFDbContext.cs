using System.Data.Entity;
using ForumMVC.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ForumMVC.Domain.Repositories
{
    public class EFDbContext : DbContext //IdentityDbContext<ApplicationUser>
    {
        public EFDbContext(string connectionString) :  base(connectionString/*"EFDbContext"*/)
        {

        }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<ClientProfile> ClientProfiles { get; set; }

        static EFDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public static EFDbContext Create(string connectionString)
        {
            return new EFDbContext(connectionString);
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
