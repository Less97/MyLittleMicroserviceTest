using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;

namespace Emailer
{
    public class EmailerSettings 
    {
        public Rabbit RabbitSettings { get; set; }

        public class Rabbit
        {
            public String Url { get; set; }
            public String Username { get; set; }
            public String Password { get; set; }
        }

    }
}
