using Newsletter.Model.Base;

namespace Newsletter.Model.Topics
{
    public class TopicSubType : EntityBase
    {
        public string Caption { get; set; }

        public TopicSubTypeEnum Type { get; set; }
    }
}
