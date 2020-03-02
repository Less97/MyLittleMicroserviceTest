using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Options;
using SharedLibrary;

namespace Emailer
{
    public class EmailerService : IHostedService
    {
        private EmailerSettings _settings;

        public EmailerService(IOptions<EmailerSettings> settings)
        {
            _settings = settings.Value;
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(_settings.RabbitSettings.Url,(ushort)_settings.RabbitSettings.Port,_settings.RabbitSettings.vHost,"connection", host =>
                {
                    host.Username(_settings.RabbitSettings.Username);
                    host.Password(_settings.RabbitSettings.Password);
                });
                cfg.ReceiveEndpoint("sendemailqueue", e =>
                {
                    e.Consumer<SendEmailConsumer>();
                });
            });
            await busControl.StartAsync();

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
