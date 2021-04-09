using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Repository
{
    public class ClientRepository : IAllClients
    {
        private readonly AppDBContext _appDBContext;
        public ClientRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<IEnumerable<Client>> Clients() => await _appDBContext.Clients
            .Include(c => c.Founders).ToListAsync();

        public async Task<IEnumerable<Client>> GetEntity() => await _appDBContext.Clients
            .Where(p => !(p.IsEntrepreneur))
            .Include(c => c.Founders).ToListAsync();

        public async Task<IEnumerable<Client>> GetIndividualEntrepreneur() => await _appDBContext.Clients
            .Where(p => p.IsEntrepreneur)
            .Include(c => c.Founders).ToListAsync();

        public void AddClient(Client client)
        {
            _appDBContext.Clients.Add(client);
            _appDBContext.SaveChanges();
        }

        public async Task<Client> GetObjectClient(int clientID) => await _appDBContext.Clients
            .Include(b => b.Founders)
            .FirstOrDefaultAsync(b => b.Id == clientID);

        public void RemoveClient(Client client)
        {
            _appDBContext.Clients.Remove(client);
            _appDBContext.SaveChanges();
        }
    }
}
