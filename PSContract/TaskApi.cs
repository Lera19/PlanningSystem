using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PSContract
{
    [DataContract]
    public class TaskApi
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime DateTimeAddeed { get; set; }
        [DataMember]
        public Statuses StatusTask { get; set; }
        [DataMember]
        public Priorities Priority { get; set; }

    }
}
