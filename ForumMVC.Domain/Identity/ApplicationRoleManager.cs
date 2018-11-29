using ForumMVC.Domain.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Identity
{
  //Это стандартные для ASP.NET Identity классы по управлению ролями и пользователями.По сути эти классы выполняют роль репозиториев.

        //public ApplicationRoleManager(RoleStore<ApplicationRole> store)
        //            : base(store)
        //{ }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(RoleStore<IdentityRole> store)
            : base(store)
        { }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                                IOwinContext context)
        {
            return new ApplicationRoleManager(new
                    RoleStore<IdentityRole>(context.Get<EFDbContext>()));
        }
    }
}
