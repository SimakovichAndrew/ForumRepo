using ForumMVC.Domain.EF;
using ForumMVC.Domain.Entities;
using ForumMVC.Domain.Identity;
using ForumMVC.Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Repositories
{
    //Класс инкапсулирует все менеджеры для работы с сущностями в виде свойств и хранит общий контекст данных.
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private EFDbContext db;

        //поля
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private ClientManager clientManager;
        private EFCommentRepository commentRepository;
        private EFTopicRepository topicRepository;
        //private EFClientRepository clientRepository;


        //конструктор
        public IdentityUnitOfWork(string connectionString)
        {
            db = new EFDbContext();
            userManager = new ApplicationUserManager(store: new UserStore<IdentityUser>(db));
            roleManager = new ApplicationRoleManager(store: new RoleStore<IdentityRole>(db));
            clientManager = new ClientManager(db);
           // clientRepository = new EFClientRepository(db);
            commentRepository = new EFCommentRepository(db);
            topicRepository = new EFTopicRepository(db);

        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }
        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        //public EFClientRepository ClientRepository
        //{
        //    get { return clientRepository; }
        //}

        public EFTopicRepository TopicRepository
        {
            get { return topicRepository; }
        }

        public EFCommentRepository CommentRepository
        {
            get { return commentRepository; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public IRepository<Topic> Topics
        {
            get
            {
                if (topicRepository == null)
                    topicRepository = new EFTopicRepository(db);
                return null;// topicRepository;
            }
        }



        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new EFCommentRepository(db);
                return null;// commentRepository;
            }
        }
        //public IRepository<IdentityUser> ClientProfiles
        //{
        //    get
        //    {
        //        if (clientManager == null)
        //            clientManager.Create(new IdentityUser());
        //        return clientManager;
        //    }
        //}

        //public IRepository<IdentityUser> Client
        //{
        //    get
        //    {
        //        if (clientRepository == null)
        //            clientRepository = new EFClientRepository(db);
        //        return clientRepository;
        //    }
        //}
        //throw new NotImplementedException();

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
