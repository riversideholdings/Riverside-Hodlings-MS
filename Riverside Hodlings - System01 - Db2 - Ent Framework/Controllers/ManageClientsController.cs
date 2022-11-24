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
            var client = new ClientsVm();
            client.Clients = db.CLIENTS.Where(cli => cli.CLIENT_ID == clientId).ToList();
            client.Invoices = db.INVOICES.Where(i => i.CLIENT_ID == clientId).OrderByDescending(C => C.INVOICE_DATE).ToList();
            client.ClientPayments = db.CLIENT_PAYMENTS.Where(py => py.CLIENT_ID == clientId).OrderByDescending(p => p.DATE).ToList();
            client.ClInvoiceNotes = db.INVOICE_NOTES.ToList();
            return View(client);
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
            var namestring = name.Substring(0, 3).ToUpper();
          
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

            return JsonConvert.SerializeObject(new { message = name + " has been added to clients successfully!" });
        }

        public string ConfirmDelete(string clId)
        {
            var clientToDelete = db.CLIENTS.Where(x => x.CLIENT_ID == clId).FirstOrDefault();
            db.CLIENTS.Remove(clientToDelete);
            var myessage = "";
            try
            {
                db.SaveChanges();
                myessage = clientToDelete.NAME.Replace(" ", "") + " has been successfully deleted!";
            }
            catch
            {
                myessage = clientToDelete.NAME.Replace(" ", "") + " Cannot be deleted, because they have invoices that belong to them in the database! Delete restricted, to allow this client to be deleted, please alter database.";
            }
            

            return JsonConvert.SerializeObject(new { message = myessage});
        }

        public ActionResult EditClient(string id)
        {
            var client = db.CLIENTS.Where(c => c.CLIENT_ID == id).ToList();
            return View(client);
        }

        public string ConfirmEdit(string clientId, string name, string phone, string email, string physicalAddress, string contactPerson)
        {
            var clientToupdate = db.CLIENTS.Where(x => x.CLIENT_ID == clientId).FirstOrDefault();

            clientToupdate.CLIENT_ID = clientId;
            clientToupdate.NAME = name;
            clientToupdate.PHONE_NUMBER = phone;
            clientToupdate.EMAIL = email;
            clientToupdate.ADDRESS = physicalAddress;
            clientToupdate.CONTACT_PERSON = contactPerson;

            var myessage = "";
            try
            {
                db.SaveChanges();
                myessage = name + " has been successfully updated!";
            }
            catch
            {
                myessage = name + " Cannot be updated. Please check for errors and try again!";
            }


            return JsonConvert.SerializeObject(new { message = myessage });
        }
    }
}