using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Models;
using TestWebAppForTheJob.ViewModels;

namespace TestWebAppForTheJob.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IAllClients _allClients;
        private readonly IClientFounders _clientFounders;
        private AppDBContext db { get; set; }

        public ClientsController(IAllClients allClients, IClientFounders clientFounders, AppDBContext context)
        {
            _allClients = allClients;
            _clientFounders = clientFounders;
            db = context;
        }

        public IActionResult ListClients()
        {
            ViewBag.Title = "Страница с клиентами";
            ClientListViewModel obj = new ClientListViewModel();
            obj.AllClient = _allClients.Clients;
            return View(obj);
        }

        public IActionResult InputFormClient()
        {
            ViewBag.Title = "Форма добавления клиента";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InputFormClient(Client client)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Title = "Форма добавления клиента";
                Debug.WriteLine(client.Id);
                Debug.WriteLine(client.Inn);
                Debug.WriteLine(client.Name);
                Debug.WriteLine(client.IsEntrepreneur);
                Debug.WriteLine(client.DateAdded);
                Debug.WriteLine(client.DateOfUpdate);
                Debug.WriteLine(client.Founders);
                db.Clients.Add(client);
                await db.SaveChangesAsync();
                return RedirectToAction("ListClients");
            }
            else
            {
                return View(client);
            }
        }

        public IActionResult InputFormFounder()
        {
            ViewBag.Title = "Форма добавления Учредителя";
            return View(new Founder() { Inn = "6666666666" });
        }
    }
}
