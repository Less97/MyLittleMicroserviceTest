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
        private readonly ISendEndpointProvider _sendEndpointProvider;
        

        public MessageSender(IOptions<RabbitSettings> rabbitSettings, ISendEndpointProvider sendEndpointProvider)
        {
            _rabbitSettings = rabbitSettings.Value;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task<bool> SendMessageAsync()
        {
            await _sendEndpointProvider.Send<SendEmailMessage>(new SendEmailMessage()
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
