using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Riverside_Hodlings___System01___Db2___Ent_Framework.Models;
using PagedList;

namespace Riverside_Hodlings___System01___Db2___Ent_Framework.Controllers
{
    public class HomeController : Controller
    {
        private Riverside_HoldingsEntities1 db = new Riverside_HoldingsEntities1();
        public ActionResult Index()
        {
            var info = new DashboardVM();
            info.Admins = db.ADMINISTRATORS.ToList();
            info.Clients = db.CLIENTS.ToList();
            info.Invoices = db.INVOICES.ToList();
            return View(info);
        }

        public ActionResult Clients(string searchString, string sortOrder, string currentFilter, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            ViewBag.CurrentSort = sortOrder;

            //
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var clients = from c in db.CLIENTS select c;

            //return results according to search
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = db.CLIENTS.Where(c => c.NAME.Contains(searchString));
            }

            ViewBag.CurrentFilter = searchString;

            return View(clients.ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Finance()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Invoices()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}