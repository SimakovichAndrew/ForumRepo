using ForumMVC.BLL.DTO;
using ForumMVC.BLL.Infrastructure;
using ForumMVC.BLL.Interfaces;
using ForumMVC.Domain.Entities;
using ForumMVC.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.BLL.Service
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> CreateUser(/*string userName, string password,*/ UserDTO userDto)
        {
            /*ApplicationUser*/
            var user =  await Database.UserManager.FindByEmailAsync(userDto.Password/*Email*/);//await Database.UserManager.FindByNameAsync(userDto.Password);
            if (user == null)
            {
                user = new ApplicationUser { /*Email*/PasswordHash = userDto.Password, UserName = userDto.UserName/*.Password*/ };
                await Database.UserManager.CreateAsync(user, userDto.Password);
                // добавляем роль
               // await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
               // создаем профиль клиента
               ClientProfile clientProfile = new ClientProfile { Id = user.Id, /*Address = userDto.Address, */Name = userDto.UserName };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");

            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
          /*  ApplicationUser*/var user = await Database.UserManager.FindAsync(userDto.UserName, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }

            await CreateUser(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

       

       
    }
}

