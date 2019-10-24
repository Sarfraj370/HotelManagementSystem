using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.Areas.Deshboard.Controllers
{
    public class DeshboardController : Controller
    {
        // GET: Deshboard/Deshboard
       //[Authorize(Roles ="Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        //AccomodationTypesService accomodationTypeService = new AccomodationTypesService();
        //// GET: Deshboard/AccomodationTypes
        //public ActionResult Index()
        //{
        //    return View();
        //}

        
    }
}