using System;
using Swampy.Business.DomainModel.Entities.Interfaces;

namespace Swampy.Business.DomainModel.Entities
{
    public class ConfigurationItem : AbstractEntity
    {
        protected ConfigurationItem()
        {
            
        }

        public ConfigurationItem(string key, string value, ConfigurationItemType type, Swampy.Business.DomainModel.Entities.SwampyEnvironment environment)
            : this()
        {
            this.Key = key;
            this.Value = value;
            this.Type = type;
            this.SwampyEnvironment = environment;
        }

    

        public virtual SwampyEnvironment SwampyEnvironment { get; set; }

        public virtual ConfigurationItemType Type { get; set; }

        public virtual bool Test()
        {
            return true;
        }

        public virtual bool StoreAsToken { get; set; }

        public virtual bool ContainsTokens(ITokenBuilder builder)
        {
            builder.SearchForTokens(this.Value);
            if (builder.TokensFound.Count > 0)
                return true;

            return false;
        }

        public virtual string Hydrate(ITokenBuilder builder)
        {
            builder.SearchForTokens(this.Value);
            if (builder.TokensFound.Count > 0)
            {
                //TODO: replace this string with 
                throw new NotImplementedException();
            }
            return this.Value;
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
