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
            this.Name = key;
            this.Value = value;
            this.ConfigurationType = type;
            this.SwampyEnvironment = environment;
        }

    

        public virtual SwampyEnvironment SwampyEnvironment { get; set; }

        public virtual ConfigurationItemType ConfigurationType { get; set; }

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
                   string replacementValue = replacementValues.Single(x => x.Name == token).Value;

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

     

        public virtual string Description { get; set; }

        public virtual string Name { get; set; }

        public virtual string Value { get; set; }

    }
}
