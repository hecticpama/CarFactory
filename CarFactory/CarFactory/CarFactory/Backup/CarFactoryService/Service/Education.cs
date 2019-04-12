using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CarFactoryService.Service
{
    [DataContract]
    public class Education
    {
        [DataMember]
        public int IdEducation { get; set; }
        [DataMember]
        public string Name { get; set; }

    }
}
