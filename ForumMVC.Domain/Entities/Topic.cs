using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Entities
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        // public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string TopicAdmin { get; set; }
        //public virtual IdentityUser User { get; set; }

        //свойство навигации
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }

        public virtual ICollection<Comment> Coments { get; set; }
    }
}
