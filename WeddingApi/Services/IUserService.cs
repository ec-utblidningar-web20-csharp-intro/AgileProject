using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WeddingApi.Services
{
    public interface IUserService
    {
        Task<IdentityUser> GetCurrentUser();
    }
}
