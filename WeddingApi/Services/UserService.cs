using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using WeddingApi.Data;

namespace WeddingApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly WeddingDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<IdentityUser> userManager,
            WeddingDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManger = userManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IdentityUser> GetCurrentUser()
        {
            var claim = _httpContextAccessor?.HttpContext?.User as ClaimsPrincipal ?? null;
            return await _userManger.GetUserAsync(claim);
        }
    }
}
