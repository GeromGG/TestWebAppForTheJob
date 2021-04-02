using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Interfaces
{
    public interface IAllClients
    {
        IEnumerable<Client> Clients { get; }
        IEnumerable<Client> GetEntity { get; set; }
        IEnumerable<Client> GetIndividualEntrepreneur { get; set; }
        Client GetObjectClient(int clientID);
    }
}
