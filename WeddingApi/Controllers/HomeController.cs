using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;
using WeddingApi.Repositories;
using WeddingApi.Services;
using WeddingApi.Utils.SaveTheDateCard;

namespace WeddingApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGuestRepository _guestRepo;
        private readonly WeddingDbContext _context;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger,
            IGuestRepository guestRepo,
            WeddingDbContext context,
            IUserService userService)
        {
            _logger = logger;
            _guestRepo = guestRepo;
            _context = context;
            _userService = userService;
        }

        public IActionResult Index()
        {

            var userId = await _userService.GetCurrentUser();

            var wedding = await _context.Weddings
                .Include(w => w.Couple)
                    .ThenInclude(c => c.Merriers)
                .Include(w => w.GuestList)
                    .ThenInclude(gl => gl.GuestUser)
                .FirstOrDefaultAsync();
            var testCard = new SaveTheDateCardBuilder(wedding, options =>
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
