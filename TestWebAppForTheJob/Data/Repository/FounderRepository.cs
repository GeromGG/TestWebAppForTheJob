using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Repository
{
    public class FounderRepository : IClientFounders
    {
        private readonly AppDBContext _appDBContext;
        public FounderRepository(AppDBContext appDBContent)
        {
            _appDBContext = appDBContent;
        }
        public async Task<IReadOnlyList<Founder>> AllFounders() => await _appDBContext.Founders.ToListAsync();

        public async Task<IReadOnlyList<Founder>> GetClientFounders(int clientID) => await _appDBContext.Founders
            .Where(a => a.ClientId == clientID
            .ToString())
            .Include(z => z.Client).ToListAsync();
    }
}
