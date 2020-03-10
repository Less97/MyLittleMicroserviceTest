﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Services.MessageSender
{
    public interface IMessageSender
    {
        Task<Boolean> SendMessageAsync(String email);
    }
}
