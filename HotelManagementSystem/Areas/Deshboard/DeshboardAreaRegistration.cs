using System.Web.Mvc;

namespace HotelManagementSystem.Areas.Deshboard
{
    public class DeshboardAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Deshboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Deshboard_default",
                "Deshboard/{controller}/{action}/{id}",
                new {Controller="Deshboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}