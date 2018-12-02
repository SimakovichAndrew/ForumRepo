using ForumMVC.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ForumMVC.BLL.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumMVC.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateUser(IdentityUser user);/*string email, string userName, string password, UserDTO*/

        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO userAdmin, List<string> roles);
    }
}
