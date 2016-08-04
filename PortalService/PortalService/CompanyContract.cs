using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PortalService
{
    [JsonObject]
    [DataContract]
    public class CompanyContract
    {
        [DataMember]
        [JsonProperty(PropertyName = "company")]
        public string company { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "change")]
        public float change { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "pctChange")]
        public float pctChange { get; set; }
    }
}

