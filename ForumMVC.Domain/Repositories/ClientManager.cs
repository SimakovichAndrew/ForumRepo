﻿using ForumMVC.Domain.EF;
using ForumMVC.Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Repositories
{
    public class ClientManager : IClientManager
    {
        public EFDbContext Database { get; set; }
        public ClientManager(EFDbContext db)
        {
            Database = db;
        }

        public void Create(IdentityUser item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
