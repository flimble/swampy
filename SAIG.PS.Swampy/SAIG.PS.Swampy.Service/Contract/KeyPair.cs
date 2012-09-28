using System;
using System.Runtime.Serialization;

namespace SAIG.PS.Swampy.Service.Contract
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
