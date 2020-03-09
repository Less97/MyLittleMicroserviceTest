using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Models;
using AccountService.Services;
using AccountService.Services.MessageSender;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMessageSender _sender;

        public AccountController(ILogger<AccountController> logger, IMessageSender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult ForgotPassword()
        {   
            return View(new ForgotPassword()
            {
                Email =  String.Empty
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(ForgotPassword password)
        {
            if (ModelState.IsValid)
            {
                ViewBag.IsValid = true;
            }
            return View(password);
        }
    }
}
