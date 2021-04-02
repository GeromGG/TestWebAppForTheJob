using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;

namespace TestWebAppForTheJob.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IAllClients _allClients;
        private readonly IClientFounders _clientFounders;

        public ClientsController(IAllClients allClients, IClientFounders clientFounders)
        {
            _allClients = allClients;
            _clientFounders = clientFounders;
        }

        public ViewResult ListClients()
        {
            var clients = _allClients.Clients;
            return View(clients);
        }
    }
}
