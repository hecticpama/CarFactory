using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CarFactoryService.Service
{
    [DataContract]
    public class Suburb
    {
        [DataMember]
        public int IdSuburb { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Country { get; set; }
    }
}
