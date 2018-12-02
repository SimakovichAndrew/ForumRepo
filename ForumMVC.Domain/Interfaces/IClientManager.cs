using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace ForumMVC.Domain.Interfaces
{
    //Данный интерфейс содержит один метод для создания нового профиля пользователя.
    public interface IClientManager : IDisposable
    {
        void Create(IdentityUser item);
    }
}
