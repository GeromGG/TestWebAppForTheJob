using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Founder> AllFounders => _appDBContext.Founders;

        public IEnumerable<Founder> GetClientFounders(int clientID) => _appDBContext.Founders.Where(a => a.ClientId == clientID.ToString()).Include(z => z.Client);
    }
}
