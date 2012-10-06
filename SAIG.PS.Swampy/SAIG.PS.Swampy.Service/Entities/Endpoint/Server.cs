using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using SAIG.PS.Swampy.Service.Entities.Endpoint;

namespace SAIG.PS.Swampy.Service.Entities
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

            }
            return false;
        }

        public override string TypeName
        {
            get { return "Application Server"; }
        }
    }
}
