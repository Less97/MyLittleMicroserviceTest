using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;
using SharedLibrary;
using WebApplication1;

namespace AccountService.Services.MessageSender
{
    public class MessageSender : IMessageSender
    {
        private RabbitSettings _rabbitSettings;
        private ISendEndpoint _messageEndpoint;

        public MessageSender(IOptions<RabbitSettings> rabbitSettings)
        {
            _rabbitSettings = rabbitSettings.Value;
        }

        public async Task<bool> SendMessageAsync()
        {
            await _messageEndpoint.Send<SendEmailMessage>(new SendEmailMessage()
            {
                To="",
                Body="",
                From="",
                Subject =""
            });
            return true;
        }
    }
}
