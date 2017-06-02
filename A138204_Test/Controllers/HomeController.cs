using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A138204_Test.Controllers
{
    public class HomeController : Controller
    {
        private IExtractPetsBusinessLogic getPetsList;

        public HomeController(IExtractPetsBusinessLogic getPetsList)
        {
            this.getPetsList = getPetsList;
        }
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
    }
}