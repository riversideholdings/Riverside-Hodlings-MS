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
    public class OrdersController : Controller
    {
        private Riverside_HoldingsEntities1 db = new Riverside_HoldingsEntities1();
        public ActionResult AllOrders(string invoiceNumber, string sortOrder, string currentFilter, int? page)
        {
            int pageSize = 15;
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
            invoices.Invoices = db.INVOICES.ToList().OrderByDescending(i => i.INVOICE_NUM).ToPagedList(pageNumber, pageSize);

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
            var invoices = new orderDetailsVm();
            invoices.ClInvoiceNotes = db.INVOICE_NOTES.Where(n => n.INVOICE_NUM == Orderid).ToList();
            invoices.Clients = db.CLIENTS.ToList();
            invoices.Products = db.PRODUCTS.ToList();
            invoices.ClientPayments = db.CLIENT_PAYMENTS.ToList();
            invoices.Invoices = db.INVOICES.Where(o => o.INVOICE_NUM == Orderid).ToList();
            invoices.Invoice_itm = db.INVOICE_ITEM.Where(itm => itm.INVOICE_NUM == Orderid).ToList();
            return View(invoices);
        }

        public ActionResult AddOrder(string LastOrderid)
        {
            var invoices = new orderDetailsVm();
            invoices.Clients = db.CLIENTS.ToList();
            invoices.Products = db.PRODUCTS.ToList();
            invoices.ClientPayments = db.CLIENT_PAYMENTS.ToList();
            invoices.Invoices = db.INVOICES.Where(o => o.INVOICE_NUM == LastOrderid).ToList();
            return View(invoices);
        }

        public ActionResult AddInvItems(string clId)
        {
            var prod = new orderDetailsVm();
            prod.Clients = db.CLIENTS.ToList();
            prod.Products = db.PRODUCTS.ToList();
            prod.ClientPayments = db.CLIENT_PAYMENTS.ToList();
            prod.Invoices = db.INVOICES.OrderByDescending(i => i.INVOICE_NUM).Take(1).ToList();
            return View(prod);
        }

        public ActionResult confirmAdditem(string product, int quantity, string invoiceID)
        {
            string message = "";

            if (product != null)
            {
                db.INVOICE_ITEM.Add(new INVOICE_ITEM { QUANTITY = quantity, PRD_CODE = product, INVOICE_NUM = invoiceID});
                db.SaveChanges();
                message = product + " Added";
            }
            else
            {
                message = "Database cannot accept null values";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        //display items
        public JsonResult GetitemsTable(string id)
        {
            //List<PRODUCT> ExampleTables = new List<PRODUCT>();
            //ExampleTables = db.PRODUCTS.ToList();

            //----------- Edit Here -----------
            var prod = new orderDetailsVm();
            prod.Products = db.PRODUCTS.ToList();
            prod.Invoice_itm = db.INVOICE_ITEM.Where(i => i.INVOICE_NUM == id).ToList();

            return Json(prod, JsonRequestBehavior.AllowGet);
        }
    }

}
