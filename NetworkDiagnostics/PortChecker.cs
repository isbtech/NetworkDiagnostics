using System;
using System.Net.Sockets;

namespace NetworkDiagnostics
{
    internal class PortChecker
    {
        public bool CheckPort(int userPort) // check if port is open
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", userPort); // attempt to connect
                return true;
            }
            catch (Exception ex)
            {
                if (ex is SocketException)
                {
                    return false;
                }

                if (ex is ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Port number out of range.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                throw;
            }
        }
    }
}