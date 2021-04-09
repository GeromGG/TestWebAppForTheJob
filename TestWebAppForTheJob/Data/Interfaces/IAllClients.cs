using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Interfaces
{
    public interface IAllClients
    {
        Task<IReadOnlyList<Client>> Clients();
        Task<IReadOnlyList<Client>> GetEntity();
        Task<IReadOnlyList<Client>> GetIndividualEntrepreneur();
        Task<Client> GetObjectClient(int clientID);
        void AddClient(Client client);
        void RemoveClient(Client client);
    }
}
