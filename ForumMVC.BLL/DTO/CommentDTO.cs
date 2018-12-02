using System;

namespace ForumMVC.BLL.DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string ComAutor { get; set; }
        public string ComContent { get; set; }
        public DateTime ComTime { get; set; }
        public string TopicName { get; set; }
    }
}
