using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
        public async Task<IActionResult> ClientEditing(int clientId)
        {
            ViewBag.Title = "Редактирование клиента";
            var obj = new ClientEditingViewModels();
            obj.Client = await _allClients.GetObjectClient(clientId);
            return View(obj.Client);
        }

        [HttpPost]
        public async Task<IActionResult> ClientRemove(int clientId)
        {
            var obj = new ClientEditingViewModels();
            obj.Client = await _allClients.GetObjectClient(clientId);
            _allClients.RemoveClient(obj.Client);
            return RedirectToAction("ListClients");
        }

        public IActionResult InputFormClient()
        {
            ViewBag.Title = "Форма добавления клиента";
            return View();
        }

        [HttpPost]
        public IActionResult InputFormClient(Client client)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Title = "Форма добавления клиента";
                _allClients.AddClient(client);
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
            return View(/*new Founder() { Inn = "6666666666" }*/);
        }
    }
}
