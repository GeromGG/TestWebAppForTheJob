using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;

namespace TestWebAppForTheJob.Controllers
{
    public class ClientController : Controller
    {
        private readonly IAllClient _allClient;
        private readonly IClientFounders _clientFounders;

        public ClientController(IAllClient allClient, IClientFounders clientFounders)
        {
            _allClient = allClient;
            _clientFounders = clientFounders;
        }

        public ViewResult ListClient()
        {
            var client = _allClient.Clients;
            return View(client);
        }
    }
}
