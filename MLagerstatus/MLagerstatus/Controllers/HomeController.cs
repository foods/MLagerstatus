using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLagerstatus.Interfaces.Repositories;
using MLagerstatus.Models;
using MLagerstatus.Models.LagerStatus;

namespace MLagerstatus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILagerRepository _lagerRepository;

        public HomeController(ILagerRepository lagerRepository)
        {
            _lagerRepository = lagerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
