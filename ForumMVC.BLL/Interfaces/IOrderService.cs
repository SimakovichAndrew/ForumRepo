using ForumMVC.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.BLL.Interfaces
{
    public interface IOrderService:IDisposable
    {
        //void CreateTopic(TopicDTO topicDto);
        void CreateComment(string content, string topicname);

        void MakeTopic(TopicDTO topicDto);
        void MakeComment(CommentDTO comentDto);
        CommentDTO GetComment(int? id);
        TopicDTO GetTopic(int? id);
        IEnumerable<CommentDTO> GetComments();
        IEnumerable<TopicDTO> GetTopics();
        //void Dispose();
        //IEnumerable<RecordDT> GetRecords();

    }
}
