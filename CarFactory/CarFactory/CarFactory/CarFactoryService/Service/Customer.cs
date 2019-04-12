using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CarFactoryService.Service
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int IdCustomer { get; set;}
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public int  IdOccupation { get; set; }
        [DataMember]
        public string JobTitle { get; set; }
        [DataMember]
        public int  IdSuburb { get; set; }
        [DataMember]
        public string SuburbName { get; set; }
        [DataMember]
        public int IdEducation { get; set; }
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public Education educ { get; set; }
        [DataMember]
        public Suburb sub { get; set; }
        [DataMember]
        public Occupation oc { get; set; }
       
    }
}
