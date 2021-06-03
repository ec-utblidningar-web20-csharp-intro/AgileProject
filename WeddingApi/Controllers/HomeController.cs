using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;
using WeddingApi.Repositories;

namespace WeddingApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGuestRepository _guestRepo;

        public HomeController(ILogger<HomeController> logger,
            IGuestRepository guestRepo)
        {
            _logger = logger;
            _guestRepo = guestRepo;
        }

        public IActionResult Index()
        {
            var options = new GuestOptionsBuilder()
            {
                HasPlusOne = true
            };
            var test = _guestRepo.Get(new Wedding(), options);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
