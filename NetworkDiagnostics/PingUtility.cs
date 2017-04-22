using System;
using System.Net.NetworkInformation;
using System.Net;

namespace NetworkDiagnostics
{
    public class PingUtility
    {

        public void PingTarget(IPAddress IPtoPing, int timeout)
        {
            Ping pinger = new Ping();

            try
            {
                PingReply reply = pinger.Send(IPtoPing, timeout);
                if (reply != null)
                {
                    Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                }
            }
            catch
            {
                Console.WriteLine("Timed out");
            }
        }
    }
}
