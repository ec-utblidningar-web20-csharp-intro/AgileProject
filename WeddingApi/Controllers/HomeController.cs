using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models;
using WeddingApi.Repositories;
using WeddingApi.Utils.SaveTheDateCard;

namespace WeddingApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGuestRepository _guestRepo;
        private readonly WeddingDbContext _context;

        public HomeController(ILogger<HomeController> logger,
            IGuestRepository guestRepo,
            WeddingDbContext context)
        {
            _logger = logger;
            _guestRepo = guestRepo;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var wedding = await _context.Weddings
                .Include(w => w.Couple)
                    .ThenInclude(c => c.Merriers)
                .Include(w => w.GuestList)
                    .ThenInclude(gl => gl.GuestUser)
                .FirstOrDefaultAsync();
            var testCard = new SaveTheDateCardBuilder(wedding, options =>
            {
                options.SendByEmail = true;
            });
            new DispatchBuilder(testCard).Deliver();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
