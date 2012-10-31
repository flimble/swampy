using System;
using Swampy.Shared.Infrastructure.Extensions;

namespace Swampy.Domain.Entities
{
    public class GlobalToken : EntityBase
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
