using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CarFactoryService.Service
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int IdOrder { get; set; }

        [DataMember]
        public int IdCustomer { get; set; }

        [DataMember]
        public int IdProduct { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public Customer customer { get; set; }

        [DataMember]
        public Product product { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

    }
}
