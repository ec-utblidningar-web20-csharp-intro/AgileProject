using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> Get(Wedding wedding, GuestOptionsBuilder options);
        Task Create(Guest guest);
        Task Delete(Guest guest);
        Task Update(Guest guest);
        Task ResetLoginCode(GuestUser guest);


    }

}
