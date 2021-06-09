using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Repositories
{
    public interface IGuestRepository
    {
        IEnumerable<Guest> Get(Wedding wedding, GuestOptionsBuilder options);
        IEnumerable<Guest> Get(int weddingId, GuestOptionsBuilder options);
        Task<Guest> Get(int id, bool asNoTracking = false);
        Task Create(Guest guest);
        Task Delete(Guest guest);
        Task Update(Guest guest);
        Task ResetLoginCode(Guest guest);
        Task ResetLoginCode(GuestUser guest);
    }

}
