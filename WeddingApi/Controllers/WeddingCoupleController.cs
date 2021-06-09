using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace WeddingApi.Controllers
{
    public class WeddingCoupleController : Controller
    {
        private readonly WeddingDbContext _context;

        public WeddingCoupleController(WeddingDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(MarrierUser marrierUser)
        {

            await _context.MarrierUser.AddAsync(marrierUser);

            //string UserEmail = User.FindFirst(ClaimTypes.Email).Value;

            //var MarrierUser = await _context.MarrierUser.Where(u => u.Email == UserEmail).FirstOrDefaultAsync();

            //var weddingCouple = await _context.WeddingCouples.Where(w => w.Merriers.Contains(MarrierUser)).FirstOrDefaultAsync();

            //weddingCouple.Merriers.Add(marrierToBeAdded);
            //_context.WeddingCouples.Update(weddingCouple);
            
            //if(await _context.SaveChangesAsync() == 1)
            return View(marrierUser);
        }
        
    }
}
