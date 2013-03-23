using System;
using System.Net.NetworkInformation;

namespace Swampy.Domain.Entities.Endpoint
{
    public class Server : EntityBase
    
    {

        public virtual Swampy.Business.DomainModel.Entities.Environment Environment { get; set; }

        public virtual string Name { get; set; }

        public virtual Business.DomainModel.ValueObjects.Domain Domain { get; set; }

        public virtual string FullyQualifiedDomainName
        {
            get { return string.Format("{0}.{1}", Name, Domain.Name); }
        }

        public virtual bool IsValid()
        {
            return Uri.CheckHostName(FullyQualifiedDomainName) == UriHostNameType.Dns;
        }

        public virtual string Key { get; set; }

        public virtual bool Test()
        {
            try
            {
                var ping = new Ping();
                PingReply pingReply = ping.Send(FullyQualifiedDomainName);
                if (pingReply != null && pingReply.Status == IPStatus.Success)
                    return true;
            }
            catch (PingException e)
            {
                var a = e;
            }
            return false;
        }

        public virtual string TypeName
        {
            get { return "Application Server"; }
        }
    }
}
