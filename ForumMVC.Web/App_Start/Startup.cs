using ForumMVC.BLL.Interfaces;
using ForumMVC.Domain.
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(ForumMVC.Web.App_Start.Startup))]

namespace ForumMVC.Web.App_Start
{
    public class Startup
    {

        //________________________________________________________________________________________________
        //IUserService userService;
        //public Startup()
        //{
        //    this.userService = (UserService)DependencyResolver.Current.GetService(typeof(UserService));
        //}
        //public void Configuration(IAppBuilder app)
        //{

        //    // настраиваем контекст
        //    app.CreatePerOwinContext<IUserService>(CreateUserService);

        //    //устанавливаем аутентификацию на основе куки
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //        LoginPath = new PathString("/Account/Register"),//неавторизованные пользователи направляются сюда
        //    });
        //}

        //private IUserService CreateUserService()
        //{
        //    return userService;
        //}


        //________________________________________________________________________________________________________________________

        private IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("EFDbContext");
        }
    }
}