using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class RabbitSettings
    {
        public String Url { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String vHost { get; set; }
        public Int32 Port { get; set; }
    }
    
}
