using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace SAIG.PS.Swampy.Service.Entities
{
    public class Server
    {
        public string Name { get; set; }

        public string Domain { get; set; }

        public string FullyQualifiedDomainName
        {
            get { return string.Format("{0}.{1}", Name, Domain); }
        }

        public bool IsValid()
        {
            return Uri.CheckHostName(FullyQualifiedDomainName) == UriHostNameType.Dns;
        }

        public bool Test()
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
    }
}
