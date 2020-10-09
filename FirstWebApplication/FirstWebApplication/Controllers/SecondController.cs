using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApplication.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MapPage()
        {
            
            ViewBag.ID = Request.Query["id"];
            ViewData["Name"] = Request.Query["name"];


            ViewData["Session"] = Request.HttpContext.Session.ToString();


            return View();
        }
    }
}