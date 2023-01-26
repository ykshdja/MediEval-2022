using MediEval.Data;
using MediEval.Hubs;
using MediEval.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Globalization;

namespace MediEval.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly AppDbContext _context;
        public ChatController(ILogger<ChatController> logger,
            IHubContext<ChatHub> hubContext,
            AppDbContext context)
        {
            _logger = logger;
            _hubContext = hubContext;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> SendMessage(String message)
        //{
        //    _hubContext.Clients.All.SendAsync(
        //            "Broadcast",
        //            new
        //            {
        //                messageBody = message,
        //                fromUser = currentUser.Email,
        //                messageDtTm = DateTime.Now.ToString(
        //                        "hh:mm tt MMM dd", CultureInfo.InvariantCulture
        //                    )
        //            });
        //}

        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult BasicChat()
        {
            return View();
        }



    }
}
