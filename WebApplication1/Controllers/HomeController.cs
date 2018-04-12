using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Create object of model call for call properties and set value
            var vSessionValue = new SessionAspDotNetMvc();
            try
            {
                // check existing value into session
                if ((Object)Session["SessionUserID"] != null)
                    // assign value into properties
                    vSessionValue.sSessionValue = "Welcome  " +
Session["SessionUserID"].ToString();
                else
                    // if session expired than set custom message
                    vSessionValue.sSessionValue = "Session Expired";
            }
            catch
            {

            }
            // return value to view
            return View(vSessionValue);
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}