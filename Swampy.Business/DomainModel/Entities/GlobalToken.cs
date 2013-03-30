using System;
using Swampy.Business.Infrastructure.Extensions;

namespace Swampy.Business.DomainModel.Entities
{
    public class GlobalToken : AbstractEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public bool IsValid()
        {
            if (!Value.IsAlphaNumeric())
                throw new ArgumentOutOfRangeException("Global Token must be alphanumeric value");
                
            return true;
        }
    }
}
