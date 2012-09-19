using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SAIG.PS.Swampy.Service
{
    [Serializable]
    [DataContract]
    public class KeyPair
    {
        public KeyPair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        [DataMember]
        public string Key { get; private set; }
        [DataMember]
        public string Value { get; private set; }
    }
}
