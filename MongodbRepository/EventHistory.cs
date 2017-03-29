using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    [Serializable]
    [CollectionName("SerialEventsDemo")]
    public class EventHistory : library.MongoEntity
    {
        public string ID { set; get; }

        public string Content { set; get; }

        public int Version { set; get; }
 
        public DateTime CreationTime { set; get; }
    }
}
