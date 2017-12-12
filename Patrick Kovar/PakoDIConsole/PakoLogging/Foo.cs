using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace PakoLogging
{
    public class Foo
    {
        public ILogger myLogger{ get; set; }
        public Foo(ILoggerFactory loggerFactory)
        {
            myLogger = loggerFactory.CreateLogger<Foo>();
        }

        public void LogSth()
        {
            myLogger.LogError("mei error");
        }
    }
}
