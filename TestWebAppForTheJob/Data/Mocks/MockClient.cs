using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Mocks
{
    public class MockClient : IAllClient
    {
        private readonly IClientFounders _clientFounders = new MockFounder();
        public IEnumerable<Client> Clients 
        {
            get {
                return new List<Client>
                {
                    new Client(id:0, inn:"123456789000", name:"ФондИвест", type: true, founder: _clientFounders.AllFounders.First()),
                    new Client(id:1, inn:"123456789033", name:"Моэстро", type: false, founder: _clientFounders.AllFounders.Last()),
                    new Client(id:2, inn:"123456789056", name:"ГолдБест", type: true, founder: _clientFounders.AllFounders.First()),
                };
            } 
        }

        public IEnumerable<Client> GetEntity { get; set; }
        public IEnumerable<Client> GetIndividualEntrepreneur { get; set; }

        public Client GetObjectClient(int clientID)
        {
            throw new NotImplementedException();
        }
    }
}
