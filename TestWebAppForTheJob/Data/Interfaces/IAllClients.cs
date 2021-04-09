using System.Collections.Generic;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Interfaces
{
    public interface IAllClients
    {
        IEnumerable<Client> Clients { get; }
        IEnumerable<Client> GetEntity { get; }
        IEnumerable<Client> GetIndividualEntrepreneur { get; }
        Client GetObjectClient(int clientID);
        void AddClient(Client client);
        void RemoveClient(Client client);
    }
}
