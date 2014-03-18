using System.Web.Mvc;

namespace WDBS.Lesma.UI.Web.Areas.En
{
    public class EnAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "En";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "En_default",
                "En/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "WDBS.Lesma.UI.Web.Areas.En.Controllers" }
            );
        }
    }
}
