using System;
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
        public IEnumerable<Founder> AllFounders => _appDBContext.Founders;
    }
}
