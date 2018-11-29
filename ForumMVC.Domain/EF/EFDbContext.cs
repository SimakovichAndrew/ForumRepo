using ForumMVC.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.EF
{
    public class EFDbContext : IdentityDbContext<ApplicationUser>
    {
        public EFDbContext() : base("EFDbContext")
        {

        }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<IdentityUser> ClientProfiles { get; set; }

        static EFDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public static EFDbContext Create()
        {
            return new EFDbContext();
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
