using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Repositories
{
    public interface IWeddingRepository
    {
        Task<Wedding> Get(int id, bool asNoTracking = false);
    }
}
