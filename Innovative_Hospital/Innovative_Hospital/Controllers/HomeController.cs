using Innovative_Hospital.Models;
using Innovative_Hospital_DAL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Innovative_Hospital.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHospitalDbContext _context;

        public HomeController(ILogger<HomeController> logger, IHospitalDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Shared()
        {
            return View();
        }

        [HttpPost]
        public List<object> GetResult()
        {
            List<object> data = new List<object>();

            List<string> labels = _context.Doctors.Select(x => $"{x.FirstName}-{x.LastName}").ToList();
            List<int> salesNumber = _context.Doctors.Select(x => x.PatientAccountings.Count()).ToList();
            data.Add(labels);
            data.Add(salesNumber);
            return data;
        }

        [HttpGet]
        public string Install(emp emp)
        {
            return "Пошел нафиг "+ emp.EMPID;
        }   
    }
}

public class emp
{
    public string EMPID { get; set; }
}
