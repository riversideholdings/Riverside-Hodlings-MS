using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Riverside_Hodlings___System01___Db2___Ent_Framework.Models
{
    public class OrdersVm
    {
        public PagedList.IPagedList<INVOICE> Invoices { get; set; }
        public List<CLIENT> Clients { get; set; }
        public List<ADMINISTRATOR> Admins { get; set; }
    }
}