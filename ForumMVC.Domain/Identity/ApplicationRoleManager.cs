using ForumMVC.Domain.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ForumMVC.Domain.Identity
{
  //Это стандартные для ASP.NET Identity классы по управлению ролями и пользователями.По сути эти классы выполняют роль репозиториев.

        //public ApplicationRoleManager(RoleStore<ApplicationRole> store)
        //            : base(store)
        //{ }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole> store)
            : base(store)
        {
        }

        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                                    IOwinContext context)
        {
            EFDbContext db = context.Get<EFDbContext>();
            ApplicationRoleManager manager = new ApplicationRoleManager(new RoleStore<IdentityRole>(db));
            return manager;
        }
    }
}
