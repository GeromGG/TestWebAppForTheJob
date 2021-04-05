using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        private Client _clientTemp { get; set; }
        private AppDBContext _db { get; set; }

        public ClientsController(IAllClients allClients, IClientFounders clientFounders, AppDBContext context)
        {
            _allClients = allClients;
            _clientFounders = clientFounders;
            _db = context;
        }

        public IActionResult DelDB(Client client)
        {
            _db.Clients.Remove(client);
            return View("ListClients");
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
                client.Founders = new List<Founder>() { new Founder() };
                _clientTemp = client;
                //ViewBag.Client = client;
                //db.Clients.Add(client);
                //await db.SaveChangesAsync();
                return View("InputFormFounder", _clientTemp);
            }
            else
            {
                return View(client);
            }
        }

        public IActionResult InputFormFounder()
        {
            ViewBag.Title = "Форма добавления учредителя";


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InputFormFounder(Client client)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Title = "Форма добавления учредителя";


                
                //Debug.WriteLine(client.Id);
                //Debug.WriteLine(client.Inn);
                //Debug.WriteLine(client.Name);
                //Debug.WriteLine(client.IsEntrepreneur);
                //Debug.WriteLine(client.DateAdded);
                //Debug.WriteLine(client.DateOfUpdate);
                //Debug.WriteLine(client.Founders);
                //Debug.WriteLine("______________");
                //Debug.WriteLine(founder.Client);
                //Debug.WriteLine(founder.FullName);
                //Debug.WriteLine(founder.Id);
                //Debug.WriteLine(founder.Inn);
                //Debug.WriteLine(founder.DateAdded);
                //Debug.WriteLine(founder.DateOfUpdate);
                //Debug.WriteLine(founder.ClientId);

                //db.Founders.Add(client.Founders.Last());
                //db.Clients.Add(client);
                //await db.SaveChangesAsync();
                //var client = new Client() { Founders = new List<Founder>() { founder } };
                return View("ListClients");
            }
            else
            {
                return View(/*client*/);
            }
        }
        //public VirtualFileResult pdf()
        //{

        //    MemoryStream m = new MemoryStream();
        //    Document document = new Document();
        //    PdfWriter.GetInstance(document, m);
        //    document.Open();
        //    document.Add(new Paragraph("Hello World"));
        //    document.Add(new Paragraph(DateTime.Now.ToString()));
        //    m.Position = 0;

        //    return File("Veb-prilozhenie_Full_Stack_v4_1.pdf", "application/pdf");
        //}
    }
}
