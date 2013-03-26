using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Swampy.Business.DomainModel.Entities.Interfaces;

namespace Swampy.Business.DomainModel.Entities
{
    public class ConfigurationItem : AbstractEntity
    {
        protected ConfigurationItem()
        {
            
        }

        public ConfigurationItem(string key, string value, ConfigurationItemType type, SwampyEnvironment environment)
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

        public virtual void Hydrate(ITokenBuilder builder, IList<ConfigurationItem> replacementValues)
        {
            var hydratedValue = new StringBuilder(this.Value);

            builder.SearchForTokens(this.Value);
            if (builder.TokensFound.Count > 0)
            {
               foreach (var token in builder.TokensFound)
               {
                   string replacementValue = replacementValues.Single(x => x.Key == token).Value;

                   hydratedValue.Replace(builder.AddTokenWrap(token), replacementValue);
               }
            }
            this.HydratedValue = hydratedValue.ToString();
        }

        public virtual string HydratedValue { get; protected set; }

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
