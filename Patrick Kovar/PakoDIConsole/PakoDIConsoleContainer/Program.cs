using Microsoft.Extensions.Configuration;
using System;

namespace PakoDIConsoleContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            AppConfig();
        }

        private static void AppConfig()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json");
            var config = configBuilder.Build();
            var outputString = config.GetSection("ConnectionStrings")["PakoConnection"];
            Console.WriteLine(outputString);
            Console.ReadLine();
        }
    }
}
