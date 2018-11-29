using ForumMVC.BLL.Ifrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateUser(/*string email, string userName, string password, UserDTO*/IdentityUser user);

        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO userAdmin, List<string> roles);
    }
}
