using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Riverside_Hodlings___System01___Db2___Ent_Framework.Models;
using PagedList;
using Newtonsoft.Json;

namespace Riverside_Hodlings___System01___Db2___Ent_Framework.Controllers
{
    public class ManageClientsController : Controller
    {
        private Riverside_HoldingsEntities1 db = new Riverside_HoldingsEntities1();
        public ActionResult ClientDetails(string clientId)
        {

            return View();
        }

        //open client add form
        public ActionResult AddClient()
        {
            var client = new ClientsVm();
            client.Clients = db.CLIENTS.OrderByDescending(C => C.DATE_ADDED).ToList();
            client.Invoices = db.INVOICES.ToList();
            return View(client);
        }

        //add client to db
        public string addClToDb(string name, string phone, string email, string physicalAddress, string contactPerson, DateTime date, string clientId)
        {
            //form a new client id
            var namestring = name.Substring(0, 3).ToUpper();
            //var lastcli = db.CLIENTS.OrderByDescending(C => C.DATE_ADDED).Take(1).ToList();
            //var numstr = Convert.ToInt32(lastcli[0].CLIENT_ID.Substring(3, 4));
            //var newnum = numstr + 1;
            //string clientId = namestring + numstr + "RH";
            
            db.CLIENTS.Add(new CLIENT { 
                CLIENT_ID = namestring+clientId+"RH",
                NAME = name,
                PHONE_NUMBER = phone,
                EMAIL = email,
                ADDRESS = physicalAddress,
                CONTACT_PERSON = contactPerson,
                DATE_ADDED = date
            });

            db.SaveChanges();

            return JsonConvert.SerializeObject(new { message = "New client added!" });
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