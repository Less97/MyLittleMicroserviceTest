using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emailer
{
    public class EmailerService : IHostedService
    {
        private EmailerSettings _settings;

        public EmailerService(EmailerSettings settings)
        {
            _settings = settings;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

      
    }
}
