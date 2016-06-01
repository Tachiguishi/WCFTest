using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WCFServicePilot101
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int ID {get;set;}

        [DataMember]
        public string Name {get;set;}
    }
}