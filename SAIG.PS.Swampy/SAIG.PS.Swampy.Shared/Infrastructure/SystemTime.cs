﻿using System;

namespace SAIG.PS.Swampy.Shared.Infrastructure
{
    /// <summary>
    /// Unit Testable Time
    /// </summary>
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
