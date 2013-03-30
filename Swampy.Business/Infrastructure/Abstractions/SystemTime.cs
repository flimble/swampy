using System;

namespace Swampy.Business.Infrastructure.Abstractions
{
    /// <summary>
    /// Unit Testable Time
    /// </summary>
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
