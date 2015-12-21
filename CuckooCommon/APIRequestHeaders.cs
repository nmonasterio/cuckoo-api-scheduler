using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace CuckooCommon
{
    public class APIRequestHeaders
    {
        public string Key { get; set; }
        public string Value { get; set; }
        [BsonIgnore]
        public string UnencrypedValue
        {
            get
            {
                return !String.IsNullOrEmpty(this.Value) ? this.Value.Substring(0, 1) : "Nothing set";
            }
        }
    }
}
