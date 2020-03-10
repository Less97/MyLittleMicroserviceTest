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
            return Task.Run(() =>
            {
                var message = context.Message;
                Console.WriteLine($"To:{message.To}");
                Console.WriteLine($"From:{message.From}");
                Console.WriteLine($"Subject:{message.Subject}");
                Console.WriteLine($"Body:{message.Body} {Environment.NewLine}<!------------------------------------!>");
            });
        }
    }
}
