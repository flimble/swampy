using System;

namespace Swampy.Domain.Infrastructure
{
    /// <summary>
    /// Unit Testable Time
    /// </summary>
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
