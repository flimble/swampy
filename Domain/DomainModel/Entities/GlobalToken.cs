﻿using System;
using Swampy.Domain.Infrastructure.Extensions;

namespace Swampy.Domain.Entities
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
