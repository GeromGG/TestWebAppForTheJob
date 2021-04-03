using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.ViewModels;

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
            ViewBag.Title = "Страница с клиентами";
            ClientListViewModel obj = new ClientListViewModel();
            obj.AllClient = _allClients.Clients;
            return View(obj);
        }

        public ViewResult InputFormClient()
        {
            ViewBag.Title = "Форма добавления клиента";
            InputFormClientViewModel obj = new InputFormClientViewModel();
            obj.AllClient = _allClients.Clients;
            return View(obj);
        }
    }
}
