using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Riverside_Hodlings___System01___Db2___Ent_Framework.Models;
using PagedList;

namespace Riverside_Hodlings___System01___Db2___Ent_Framework.Controllers
{
    public class ManageClientsController : Controller
    {
        private Riverside_HoldingsEntities1 db = new Riverside_HoldingsEntities1();
        public ActionResult ClientDetails(string clientId)
        {

            return View();
        }
        public ActionResult AddClient()
        {
            var client = new ClientsVm();
            client.Clients = db.CLIENTS.OrderByDescending(C => C.DATE_ADDED).ToList();
            client.Invoices = db.INVOICES.ToList();
            return View(client);
        }
        public ActionResult EditClient()
        {

            return View();
        }
        public ActionResult DeleteClient(string clientId)
        {
            var client = db.CLIENTS.ToList().Where(c => c.CLIENT_ID == clientId);
            return View(client.ToList());
        }

        public ActionResult ConfirmDelete()
        {

            return View();
        }
    }
}