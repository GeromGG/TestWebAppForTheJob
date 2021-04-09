using System.Collections.Generic;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.ViewModels
{
    public class ClientListViewModel
    {
        public IEnumerable<Client> AllClient { get; set; }
        public Client Client { get; set; }
    }
}
