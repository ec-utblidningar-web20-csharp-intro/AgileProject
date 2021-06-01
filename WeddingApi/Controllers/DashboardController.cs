using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models.Couple;
using WeddingApi.Models.GuestTableImg;

namespace WeddingApi.Controllers
{
    public class DashboardController : Controller
    {
        private static WeddingDbContext _context { get; set; }
        private static WeddingCouple _weddingCouple { get; set; }

        public DashboardController(WeddingDbContext context, WeddingCouple weddingCouple)
        {
            _context = context;
            _weddingCouple = weddingCouple;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bookings()
        {
            return View();
        }

        
        public ActionResult PrepareMenu()
        {
            return View();
        }

        
        public ActionResult DrinkOrder()
        {
            return View();
        }

        public ActionResult BarOptions()
        {
            return View();
        }

        public ActionResult GuestList()
        {
            return View();
        }

        public ActionResult GuestTable()
        {
            return View(_context.GuestTables.ToList());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddGuestTable(int id)
        {

            return View();

        }

    
    }
}
