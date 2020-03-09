using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;
using WebApplication1;

namespace AccountService.Services.MessageSender
{
    public class MessageSender : IMessageSender
    {
        private RabbitSettings _rabbitSettings;

        public MessageSender(IOptions<RabbitSettings> rabbitSettings)
        {
            _rabbitSettings = rabbitSettings.Value;
        }

        public Task<bool> SendMessageAsync()
        {
            return new Task<Boolean>(() => true );
        }
    }
}
