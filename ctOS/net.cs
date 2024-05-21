using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;
using Cosmos.System.Network;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.IPv4.UDP.DNS;

namespace ctOS
{
    internal class net
    {
        public NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0");      //setup network device
        public void net_manual_setup_IPv4()
        {
            IPConfig.Enable(nic, new Address(192, 168, 1, 64), new Address(255, 255, 255, 0), new Address(192, 168, 1, 254));   //IPv4 configuration
        }

        public void net_auto_setup_IPv4()
        {
            using(var xClient = new DHCPClient())
            {
                xClient.SendDiscoverPacket();
            }
        }

        public void GetIP()
        {
            Console.WriteLine("Local IP: " + NetworkConfiguration.CurrentAddress.ToString());
        }

        public Address dns(string site)
        {
            using (var xClient = new DnsClient())
            {
                xClient.Connect(new Address(8, 8, 8, 8));
                xClient.SendAsk(site);
                Address destination = xClient.Receive();
                return destination;
            }
        }
    }
}
