﻿using HMS.Entities;
using HMS.Services;
using HotelManagementSystem.Areas.Deshboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementSystem.Areas.Deshboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        // GET: Deshboard/AccomodationTypes
        public ActionResult Index(string searchTerm)
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();
            model.SearchTerm = searchTerm;
            model.AccomodationTypes = accomodationTypesService.SearchAccomodationTypes(searchTerm);
            return View(model);
        }

        public ActionResult Listing()
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();
            model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            return PartialView("_Listing", model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();
            if (ID.HasValue) //we are trying to edit a record
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(ID.Value);
                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }
            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0) //we are trying to edit a record
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(model.ID);
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                result = accomodationTypesService.UpdateAccomodationType(accomodationType);
            }
            else //we are trying to create a record
            {
                AccomodationType accomodationType = new AccomodationType();
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;
                result = accomodationTypesService.SaveAccomodationType(accomodationType);
            }
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Types." };
            }
            return json;
        }

    }
}