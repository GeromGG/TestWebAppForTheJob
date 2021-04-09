﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Interfaces
{
    public interface IAllClients
    {
        Task<IEnumerable<Client>> Clients();
        Task<IEnumerable<Client>> GetEntity();
        Task<IEnumerable<Client>> GetIndividualEntrepreneur();
        Task<Client> GetObjectClient(int clientID);
        void AddClient(Client client);
        void RemoveClient(Client client);
    }
}
