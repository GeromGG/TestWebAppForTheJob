using Microsoft.EntityFrameworkCore;
using System;
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
        public IEnumerable<Client> Clients => _appDBContext.Clients.Include(c => c.Founders);

        public IEnumerable<Client> GetEntity => _appDBContext.Clients.Where(p => !(p.IsEntrepreneur)).Include(c => c.Founders);
        public IEnumerable<Client> GetIndividualEntrepreneur => _appDBContext.Clients.Where(p => p.IsEntrepreneur).Include(c => c.Founders);

        public void AddClient(Client client)
        {
            _appDBContext.Clients.Add(client);
            _appDBContext.SaveChanges();
        }

        public Client GetObjectClient(int clientID) => _appDBContext.Clients.Include(b => b.Founders).FirstOrDefault(b => b.Id == clientID);

        public void RemoveClient(Client client)
        {
            _appDBContext.Clients.Remove(client);
            _appDBContext.SaveChanges();
        }
    }
}
