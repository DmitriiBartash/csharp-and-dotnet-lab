using System;
using System.ServiceModel;

namespace ChatHost
{
    internal class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(WCFChat.ServiceChat)))
            {
                try
                {
                    host.Open();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("WCF service host started successfully.");
                    Console.ResetColor();

                    Console.WriteLine("Press Enter to stop...");
                    Console.ReadLine();

                    host.Close();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error while starting the host:");
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();

                    if (host.State == CommunicationState.Faulted)
                    {
                        host.Abort();
                    }
                }
            }
        }
    }
}
