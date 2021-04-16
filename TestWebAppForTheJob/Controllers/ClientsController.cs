using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Models;
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

        public async Task<IActionResult> ListClients()
        {
            ViewBag.Title = "Страница с клиентами";
            var obj = new ClientListViewModel();
            obj.AllClient = await _allClients.Clients();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClientEditing(int clientId)
        {
            ViewBag.Title = "Редактирование клиента";
            var obj = new ClientEditingViewModels();
            obj.Client = await _allClients.GetObjectClient(clientId);
            return View(obj.Client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClientRemove(int clientId)
        {
            var obj = new ClientEditingViewModels();
            obj.Client = await _allClients.GetObjectClient(clientId);
            _allClients.RemoveClient(obj.Client);
            _clientFounders.RemoveFounders(obj.Client);
            return RedirectToAction("ListClients");
        }

        public IActionResult InputFormClient()
        {
            ViewBag.Title = "Форма добавления клиента";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InputFormClient(Client client)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Title = "Форма добавления клиента";

                _allClients.AddClient(client);
                return RedirectToAction("InputFormFounder");
            }
            else
            {
                return View(client);
            }
        }

        public async Task<IActionResult> InputFormFounder()
        {
            ViewBag.Title = "Форма добавления учредителя";
            var obj = new ClientListViewModel();
            obj.AllClient = await _allClients.Clients();
            var AllClientNoEntrepreneur = new List<Client>();
            foreach (var item in obj.AllClient)
            {
                if (!item.IsEntrepreneur || item.Founders.Count < 1)
                {
                    AllClientNoEntrepreneur.Add(item);
                }
            }
            ViewBag.Clients = new SelectList(AllClientNoEntrepreneur, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InputFormFounder(Founder founder)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Title = "Форма добавления учредителя";
                var client = await _allClients.GetObjectClient(Int16.Parse(founder.ClientId));
                founder.Client = client;
                _clientFounders.AddFounder(founder);
                return RedirectToAction("ListClients");
            }
            else
            {
                var obj = new ClientListViewModel();
                obj.AllClient = await _allClients.Clients();
                var AllClientNoEntrepreneur = new List<Client>();
                foreach (var item in obj.AllClient)
                {
                    if (!item.IsEntrepreneur || item.Founders.Count < 1)
                    {
                        AllClientNoEntrepreneur.Add(item);
                    }
                }
                ViewBag.Clients = new SelectList(AllClientNoEntrepreneur, "Id", "Name");
                return View();
            }
        }
    }
}
