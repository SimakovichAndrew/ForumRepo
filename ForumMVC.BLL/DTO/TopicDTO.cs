using System;

namespace ForumMVC.BLL.DTO
{
    public class TopicDTO
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string TopicAdmin { get; set; }

    }
}
