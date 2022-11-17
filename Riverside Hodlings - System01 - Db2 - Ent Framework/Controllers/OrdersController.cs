using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Riverside_Hodlings___System01___Db2___Ent_Framework.Models;
using PagedList;

namespace Riverside_Hodlings___System01___Db2___Ent_Framework.Controllers
{
    public class OrdersController : Controller
    {
        private Riverside_HoldingsEntities1 db = new Riverside_HoldingsEntities1();
        public ActionResult AllOrders(string searchString, string sortOrder, string currentFilter, int? page)
        {
            int pageSize = 10;
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

            var invoices = from c in db.INVOICES select c;

            //return results according to search
            if (!String.IsNullOrEmpty(searchString))
            {
                invoices = db.INVOICES.Where(i => i.INVOICE_NUM.Contains(searchString));
            }

            ViewBag.CurrentFilter = searchString;

            return View();
        }
    }
}