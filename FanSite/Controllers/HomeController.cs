using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FanSite.Models;
using System.Web;
using FanSite.Repositories;

namespace FanSite.Controllers
{
    public class HomeController : Controller
    {
        //IStoryRepository repo;

        //need to tell the startup.cs what interface to pass in here
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
