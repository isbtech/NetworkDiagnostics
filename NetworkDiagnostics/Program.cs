using System;

namespace NetworkDiagnostics
{


    internal class Program
    {


        private static void Main(string[] args)
        {

           

            while (true)
            {
                Console.Title = "Network Diagnostics";
                Console.Clear();
                Console.Write("Which tool would you like to use?\n0 - Close the tool\n1 - Port Checker\n2 - Ping Utility\nEnter a number: ");

                var input = Console.ReadLine();
                int toolNumber;
                if (Int32.TryParse(input, out toolNumber))
                {
                    ToolIdentifier.SelectTool((ToolIdentifier.ToolID)toolNumber);
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadLine();
                }




            }
        }
    }
}
