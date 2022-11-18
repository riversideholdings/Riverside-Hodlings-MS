﻿using System;
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
        public ActionResult AllOrders(string invoiceNumber, string sortOrder, string currentFilter, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            ViewBag.CurrentSort = sortOrder;

            //
            if (invoiceNumber != null)
            {
                page = 1;
            }
            else
            {
                invoiceNumber = currentFilter;
            }

        
            var invoices = new OrdersVm();
            invoices.Admins = db.ADMINISTRATORS.ToList();
            invoices.Clients = db.CLIENTS.ToList();
            invoices.Invoices = db.INVOICES.ToList().ToPagedList(pageNumber, pageSize);

            //return results according to search
            if (!String.IsNullOrEmpty(invoiceNumber))
            {
                invoices.Invoices = db.INVOICES.ToList().Where(i => i.INVOICE_NUM.Contains(invoiceNumber)).ToPagedList(pageNumber,pageSize);
            }

            ViewBag.CurrentFilter = invoiceNumber;

            return View(invoices);
        }

        public ActionResult OrderDetails(string Orderid)
        {
            var invoices = new DashboardVM();
            invoices.Admins = db.ADMINISTRATORS.ToList();
            invoices.Clients = db.CLIENTS.ToList();
            invoices.Invoices = db.INVOICES.Where(o => o.INVOICE_NUM == Orderid).ToList();
            return View(invoices);
        }
    }
}