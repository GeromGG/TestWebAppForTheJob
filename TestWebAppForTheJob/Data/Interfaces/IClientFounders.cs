using System.Collections.Generic;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Interfaces
{
    public interface IClientFounders
    {
        IEnumerable<Founder> AllFounders { get; }
        IEnumerable<Founder> GetClientFounders(int clientID);
    }
}
