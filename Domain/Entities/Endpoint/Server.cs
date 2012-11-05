using System;
using System.Net.NetworkInformation;

namespace Swampy.Domain.Entities.Endpoint
{
    public class Server : EndpointBase
    {
        public string Name { get; set; }

        public string Domain { get; set; }

        public string FullyQualifiedDomainName
        {
            get { return string.Format("{0}.{1}", Name, Domain); }
        }

        public override bool IsValid()
        {
            return Uri.CheckHostName(FullyQualifiedDomainName) == UriHostNameType.Dns;
        }

        public override bool Test()
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

        public override string TypeName
        {
            get { return "Application Server"; }
        }
    }
}
