using System;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Domain.Entities.Endpoint
{
    public enum ConfigurationItemType
    {
        Simple=1,
        DatabaseConnectionString=2,
        ServerUrl=3
    }

    public class ConfigurationItem : EntityBase
    {
        protected ConfigurationItem()
        {
            
        }

        public ConfigurationItem(string key, string value, ConfigurationItemType type, Swampy.Business.DomainModel.Entities.Environment environment)
            : this()
        {
            this.Key = key;
            this.Value = value;
            this.Type = type;
            this.Environment = environment;
        }

        public virtual bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Value);
        }

        public virtual Swampy.Business.DomainModel.Entities.Environment Environment { get; set; }

        public virtual ConfigurationItemType Type { get; set; }

        public virtual bool Test()
        {
            return true;
        }

        public virtual bool ContainsTokens(ITokenBuilder builder)
        {
            throw new NotImplementedException();
        }

        public virtual  string TypeName
        {
            get { return "Simple String Endpoint"; }
        }

        private string _key;

        public virtual string Key
        {
            get { return _key; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException("Endpoint Key cannot be null or empty");
                _key = value;
            }
        }

        public virtual string Description { get; set; }

        public virtual string Value { get; set; }

    }
}
