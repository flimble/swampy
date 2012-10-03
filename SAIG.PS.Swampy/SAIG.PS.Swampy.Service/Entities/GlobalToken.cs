using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAIG.PS.Swampy.Shared.Infrastructure.Extensions;

namespace SAIG.PS.Swampy.Service.Entities
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
