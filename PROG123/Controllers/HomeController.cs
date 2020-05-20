using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PROG123.DAL;
using PROG123.Models;
using PROG123.utils;

namespace PROG123.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // this is for testing purpuse only.
            DatabaseHelper dbh = new DatabaseHelper(_configuration);
            ConnStatusModel status = dbh.GetConnectionStringAndConnectionStatus();
            ViewBag.ConnStr = status.ConnStr;
            ViewBag.DBStatus = status.DBConnectionStatus;
            ViewBag.Exception = status.Exception;
            return View();
        }

        // add your actions here 
        /*public IActionResult FirstName()
        {
            string s = new Human().FirstName;
        }  */

        // action for page 2 

        string personID;
        public IActionResult Page2(PersonModel personModel)
        {
            personID = new DALPerson(_configuration).AddPerson(personModel);
            _configuration.GetSection(personID);

            return View(personModel);
        }
        public IActionResult EditPerson(PersonModel personModel)
        {
            personID = new DALPerson(_configuration).AddPerson(personModel);
            _configuration.GetSection(personID);
            personModel.PersonID = personID;
            // ViewBag.id = personID;
            // Response.Redirect("EditPerson.cshtml");
            return View(personModel);
        }

        public IActionResult UpdatePerson(PersonModel personModel) {
            new DALPerson(_configuration).UpdatePerson(personModel);
          

            return View(personModel);
        }

        public IActionResult DeletePerson(PersonModel personModel)
        {
            new DALPerson(_configuration).DeletePerson(personModel.PersonID);


            return View();
        }

    }//модиф доступа * 
    
}
