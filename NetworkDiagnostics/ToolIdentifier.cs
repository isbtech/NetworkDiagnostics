using System;
using System.Net;

namespace NetworkDiagnostics
{

    public static class ToolIdentifier
    {
        public enum ToolID { None, PortChecker, PingUtility }



        public static void SelectTool(ToolID id)
        {


            switch (id)
            {

                case ToolID.None:
                    Console.Title = "Closing";
                    Environment.Exit(0);
                    break;

                case ToolID.PortChecker:
                    Console.Title = "Port Checker";
                    Console.Clear();
                    PortChecker check = new PortChecker();
                    Console.Write("Which port would you like to check? \nEnter a port number: ");
                    int portToCheck;
                    try
                    {
                        portToCheck = Convert.ToInt32(Console.ReadLine());

                        if (portToCheck < 0)
                        {
                            Console.WriteLine("Invalid input, press any key to return.");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Checking if port {0} is open...", portToCheck);
                        bool portIsOpen = check.CheckPort(portToCheck);
                        Console.WriteLine("Port {0} is {1}", portToCheck, portIsOpen ? "open" : "closed" + "\nPress any key to continue.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input, press any key to return.");
                    }

                    Console.ReadKey();
                    break;

                case ToolID.PingUtility:
                    Console.Title = "Ping Utility";
                    Console.Clear();
                    int timeout;
                    try
                    {
                        Console.Write("\nEnter the timeout value in ms (default is 120ms): ");
                        timeout = Convert.ToInt32(Console.ReadLine());
                        if (timeout <= 0 || timeout > 10000)
                        {
                            Console.WriteLine("Invalid input, using default 120ms");
                            timeout = 120;

                        }

                    }
                    catch (Exception ex)
                    {
                        if (ex is FormatException || ex is OverflowException)
                        {
                            Console.WriteLine("Invalid input, using default 120ms");
                            timeout = 120;
                        }
                        else
                        {
                            throw;
                        }

                    }
                    while (true)
                    {
                        Console.Write("Enter the IP address to ping: ");
                        string IPtoPing = Console.ReadLine();
                        if (IPAddress.TryParse(IPtoPing, out IPAddress address))
                        {
                            PingUtility pinger = new PingUtility();
                            pinger.PingTarget(address, timeout);
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Write("Invalid input");
                            Console.ReadLine();

                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid ToolID");
                    Console.ReadKey();
                    break;
            }
        }
    }
}