using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Mocks
{
    public class MockClient : IAllClients
    {
        private readonly IClientFounders _clientFounders = new MockFounder();

        public IEnumerable<Client> Clients
        {
            get
            {
                return new List<Client>
                {
                    new Client(inn:"123456789000", name:"ФондИвест", isEntrepreneur: false, founder: new List<Founder>(){_clientFounders.AllFounders.ElementAt(0), _clientFounders.AllFounders.ElementAt(3)}),
                    new Client(inn:"123456789033", name:"Моэстро", isEntrepreneur: false, founder: new List<Founder>(){_clientFounders.AllFounders.ElementAt(1), _clientFounders.AllFounders.ElementAt(2)}),
                    new Client(inn:"123456789056", name:"ГолдБест", isEntrepreneur: true, founder: new List<Founder>(){_clientFounders.AllFounders.ElementAt(4)}),

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
