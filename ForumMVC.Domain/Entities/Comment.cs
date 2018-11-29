using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string ComAutor { get; set; }
        public string ComContent { get; set; }
        public DateTime ComTime { get; set; }
        public string TopicName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
