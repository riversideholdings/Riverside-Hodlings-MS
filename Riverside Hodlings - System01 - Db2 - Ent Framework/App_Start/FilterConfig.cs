using System.Web;
using System.Web.Mvc;

namespace Riverside_Hodlings___System01___Db2___Ent_Framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
