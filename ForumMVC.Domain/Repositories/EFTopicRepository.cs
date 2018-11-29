using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumMVC.Domain.Interfaces;
using ForumMVC.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumMVC.Domain.EF
{
   public class EFTopicRepository: IRepository<Topic> //ITopicRepositoryIRepository<Topic>
    {
        private EFDbContext dbTopicContext = new EFDbContext();
        //public IQueryable<Topic> Topics => throw new NotImplementedException();

        public IQueryable<Topic> Topics/*Products*/ => dbTopicContext.Topics;

        public IEnumerable<IdentityUser> All => throw new NotImplementedException();

        public EFTopicRepository (EFDbContext context)
        {
            dbTopicContext = context;
        }
        public void Create(Topic item)
        {
            dbTopicContext.Topics.Add(item);
        }

        public void Delete(int id)
        {
            Topic doctor = dbTopicContext.Topics.Find(id);
            if (doctor != null)
                dbTopicContext.Topics.Remove(doctor);
        }

        public IQueryable<Topic> Find(Func<Topic, bool> predicate)
        {
            return dbTopicContext.Topics.Where(predicate).AsQueryable();/*ToList*/
        }

        public Topic Get(int id)
        {
            return dbTopicContext.Topics.Find(id);
        }

        public IQueryable<Topic> GetAll()
        {
            return dbTopicContext.Topics;
        }

        public void Update(Topic item)
        {
            dbTopicContext.Entry(item).State = EntityState.Modified;
        }


        //public IQueryable<Topic> Topics
        //{
        //    get { return dbTopicContext.Topics; }
        //}
    }
}
