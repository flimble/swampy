using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Swampy.Business.DomainModel.Entities.Interfaces;

namespace Swampy.Business.DomainModel.Entities
{
    public class ConfigurationItem : AbstractEntity
    {
        private ITokenBuilder _builder;

        protected ConfigurationItem()
        {
            _builder = new TokenBuilder();
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

        public virtual bool ContainsTokens()
        {
            _builder.SearchForTokens(this.Value);
            if (_builder.TokensFound.Count > 0)
                return true;

            return false;
        }

        public virtual void Hydrate(IList<ConfigurationItem> replacementValues)
        {
            var hydratedValue = new StringBuilder(this.Value);

            _builder.SearchForTokens(this.Value);
            if (_builder.TokensFound.Count > 0)
            {
               foreach (var token in _builder.TokensFound)
               {
                   var dependency = replacementValues.SingleOrDefault(x => x.Name == token);
                   if (dependency == null)
                       throw new InvalidOperationException(string.Format("No valid replacement value exists for token {0}", token));
                  
                       string replacementValue = dependency.Value;

                       hydratedValue.Replace(_builder.AddTokenWrap(token), replacementValue);
                   
               }
            }
            this.HydratedValue = hydratedValue.ToString();
        }

        public virtual string HydratedValue { get; protected set; }
     

        public virtual string Description { get; set; }

        public virtual string Name { get; set; }

        public virtual string Value { get; set; }

    }
}
