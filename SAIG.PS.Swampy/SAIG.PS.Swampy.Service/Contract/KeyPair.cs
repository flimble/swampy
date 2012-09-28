using System;
using System.Runtime.Serialization;

namespace SAIG.PS.Swampy.Service.Contract
{
    /// <summary>
    /// Basic KeyPair type. Replacement for .NET KeyValuePair as a serializable POCO for communication with Java and other non - .NET services
    /// </summary>
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
