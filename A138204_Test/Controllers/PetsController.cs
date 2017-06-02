using A138204_Test.Attributes;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A138204_Test.Controllers
{
    public class PetsController : Controller
    {
        private IExtractPetsBusinessLogic getPetsList;

        public PetsController(IExtractPetsBusinessLogic getPetsList)
        {
            this.getPetsList = getPetsList;
        }
        // GET: Pets
        [ExceptionHandler]
        public ActionResult Pets()
        {
            var sortedList = getPetsList.getSortedPetsbyGender();

            if(sortedList == null)
            {
                sortedList.ErrorMessage = "Error Loading Data";
            }
            return View(sortedList);
        }
    }
}