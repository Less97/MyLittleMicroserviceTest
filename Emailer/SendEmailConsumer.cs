using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using SharedLibrary;

namespace Emailer
{
    public class SendEmailConsumer : IConsumer<SendEmailMessage>
    {
        public Task Consume(ConsumeContext<SendEmailMessage> context)
        {
            return Task.Run(() => { Console.WriteLine("Sending email"); });
        }
    }
}
