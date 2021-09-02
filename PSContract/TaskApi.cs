using System;
using System.Runtime.Serialization;

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