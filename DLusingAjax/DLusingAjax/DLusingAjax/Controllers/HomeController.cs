using DLusingAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLusingAjax.Controllers
{
    public class HomeController : Controller
    {
        dbDLusingAjaxEntities aentities = new dbDLusingAjaxEntities();
        public ActionResult Index()
        {
            ViewBag.countries = aentities.Countries.ToList();
            return View();
        }
        [HttpGet]
        public JsonResult StateDL(int CountryId)
        {
            var states = aentities.States.Where(s => s.CountryId == CountryId).Select
                (s => new
                {
                    Id = s.StateId,
                    Name = s.StateName
                }).ToList();
            return Json(new { msg = "success", data = states }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult DistrictDL(int StateId)
        {
            var districts = aentities.Districts.Where(s => s.StateId == StateId).Select
                (s => new
                {
                    Id = s.DistrictId,
                    Name = s.DistrictName
                }).ToList();
            return Json(new { msg = "success", data = districts }, JsonRequestBehavior.AllowGet);

        }

    }
}