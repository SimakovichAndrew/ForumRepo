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
   public class EFCommentRepository : IRepository<Comment> //ICommentRepository 
    {
        private EFDbContext dbCommentContext = new EFDbContext();
        public IQueryable<Comment> Comments => dbCommentContext.Comments;

        public IEnumerable<IdentityUser> All => throw new NotImplementedException();

        // public IEnumerable<ClientProfile> All => dbCommentContext.Comments.AsEnumerable();//throw new NotImplementedException();

        public EFCommentRepository(EFDbContext context)
        {
            dbCommentContext = context;
        }
        public void Create(Comment item)
        {
            dbCommentContext.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comment comment = dbCommentContext.Comments.Find(id);
            if (comment != null)
                dbCommentContext.Comments.Remove(comment);
        }

        public IQueryable<Comment> Find(Func<Comment, bool> predicate)
        {
            return dbCommentContext.Comments.Where(predicate).AsQueryable();
        }

        public Comment Get(int id)
        {
            return dbCommentContext.Comments.Find(id);
        }

        public IQueryable<Comment> GetAll()
        {
            return dbCommentContext.Comments;
        }

        public void Update(Comment item)
        {
            dbCommentContext.Entry(item).State = EntityState.Modified;
        }


        //public IQueryable<Comment> Comments
        //{
        //    get { return dbCommentContext.Comments; }
        //}
    }
}
