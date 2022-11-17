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
        public ActionResult ClientDetails()
        {

            return View();
        }
        public ActionResult AddClient()
        {
            
            return View();
        }
        public ActionResult EditClient()
        {

            return View();
        }
        public ActionResult DeleteClient(string id)
        {
            var client = db.CLIENTS.ToList().Where(c => c.CLIENT_ID == id);
            return View(client.ToList());
        }

        public ActionResult ConfirmDelete()
        {

            return View();
        }
    }
}