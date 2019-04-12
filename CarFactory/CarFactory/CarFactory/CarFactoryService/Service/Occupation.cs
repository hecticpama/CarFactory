﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CarFactoryService.Service
{
    [DataContract]
    public class Occupation
    {
        [DataMember]
        public int IdOccupation { get; set; }

        [DataMember]
        public string Description { get; set; }

    }
}
