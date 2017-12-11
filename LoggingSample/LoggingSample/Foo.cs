using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingSample
{
    public class Foo
    {
        private readonly ILogger<Foo> log;
        public Foo(ILoggerFactory logger)
        {
            log = logger.CreateLogger<Foo>();
        }

        public void Bar()
        {
            log.LogInformation("Bar started");
            Console.WriteLine("bar");
            log.LogError("some error in Bar");
        }
    }
}
