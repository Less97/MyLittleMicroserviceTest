using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;
using SharedLibrary;
using WebApplication1;

namespace AccountService.Services.MessageSender
{
    public class MessageSender : IMessageSender
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;
        

        public MessageSender(IBus bus, ILogger<MessageSender> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public async Task<bool> SendMessageAsync(String email)
        {
            try
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/sendemailqueue"));
                await endpoint.Send<SendEmailMessage>(new SendEmailMessage()
                {
                    To = email,
                    Body = "Please click on the following link to restore your password",
                    From = "noreply@mysitetest.com",
                    Subject = "Forgot email"
                });
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;
            }
        }
    }
}
