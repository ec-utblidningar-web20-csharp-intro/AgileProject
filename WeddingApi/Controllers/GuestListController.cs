using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Data;
using WeddingApi.Models;
using WeddingApi.Repositories;
using WeddingApi.Services;

namespace WeddingApi.Controllers
{
    public class GuestListController : Controller
    {
        private readonly WeddingDbContext _context;
        private readonly IGuestRepository _guestRepository;
        private readonly IWeddingRepository _weddingRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserService _userService;

        public GuestListController(WeddingDbContext context,
            IGuestRepository guestRepository,
            IWeddingRepository weddingRepository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUserService userService)
        {
            _context = context;
            _guestRepository = guestRepository;
            _weddingRepository = weddingRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        // GET: GuestList
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return View();
            }
            return View( _guestRepository.Get((int)id, new GuestOptionsBuilder()));               
        }

        // GET: GuestList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _guestRepository.Get((int)id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // GET: GuestList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GuestList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Gender,Email,Country,City,Allergies,AmountKids,Side,FriendsOrFamily,Answer,HasPlusOne,NeedTransportation,NeedLodging")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                await _guestRepository.Create(guest);
                return RedirectToAction(nameof(Index));
            }
            return View(guest);
        }

        // GET: GuestList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _guestRepository.Get((int)id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }

        // POST: GuestList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Gender,Email,Country,City,Allergies,AmountKids,Side,FriendsOrFamily,Answer,HasPlusOne,NeedTransportation,NeedLodging")] Guest guest)
        {
            var GetGuest = await _guestRepository.Get(id);
            

            //await _signInManager.SignInAsync(await _context.MarrierUser.FirstOrDefaultAsync(), false);
            var user = await _userService.GetCurrentUser();

            if (id != GetGuest.Id)
            {
                return NotFound();
            }
            var getcouple = await _context.WeddingCouples
                .Where(wc => wc.Merriers == user)
                .FirstOrDefaultAsync();

            var GetWedding = await _weddingRepository.Get(getcouple.Id);
            if (ModelState.IsValid)
            {
                try
                {
                    await _guestRepository.Update(guest);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return await Index(GetWedding.Id);
            }
            return await Index(GetWedding.Id);
        }

        // GET: GuestList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _guestRepository.Get((int)id, false);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: GuestList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guest = await _guestRepository.Get((int)id, false);
            await _guestRepository.Delete(guest);
            return RedirectToAction(nameof(Index));
        }

        private bool GuestExists(int id)
        {
            return _context.Guests.Any(e => e.Id == id);
        }
    }
}
