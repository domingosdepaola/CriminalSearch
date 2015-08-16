using CriminalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Application; 

namespace CriminalWebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }
        public HomeController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public ActionResult Index()
        {
            CriminalApplication criminalApplication = new CriminalApplication();
            ViewBag.DropdownCountry = new SelectList
                (
                    criminalApplication.repositoryCountry.ListAll(),
                    "Id",
                    "Description"
                );
            ViewBag.DropdownSex = new SelectList
               (
                   criminalApplication.repositorySexType.ListAll(),
                   "Id",
                   "Description"
               );
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Criminal Search Web Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Domingos now";

            return View();
        }
        [HttpPost]
        public ActionResult SearchCriminals(FormCollection collection)
        {
            bool result = false;
            try
            {
                string searchTerm = collection["Search"];
                string name = collection["Name"];
                int? ageStart = null;
                int? ageEnd = null;
                int? idCountry = null;
                int? idSexType = null;
                if (collection["AgeStart"] != string.Empty) 
                {
                    ageStart = Convert.ToInt32(collection["AgeStart"]);  
                }
                if (collection["AgeEnd"] != string.Empty) 
                {
                    ageEnd = Convert.ToInt32(collection["AgeEnd"]);
                }
                if (collection["Country"] != string.Empty) 
                {
                    idCountry = Convert.ToInt32(collection["Country"]);
                }
                if(collection["SexType"] != string.Empty)
                {
                    idSexType = Convert.ToInt32(collection["SexType"]);
                }
                string x = collection["WWWSADASD"];
                var user = UserManager.FindById(User.Identity.GetUserId());
                CriminalServiceReference.ServiceCriminalClient serviceCriminal = new CriminalServiceReference.ServiceCriminalClient();
                result = serviceCriminal.SearchCriminalList(user.Email, searchTerm, name, ageStart, ageEnd, idSexType, idCountry);

                // TODO: Add update logic here

                return Json(result);
            }
            catch
            {
                return Json(result);
            }
        }
    }
}