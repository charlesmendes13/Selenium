using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Selenium.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Selenium.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var sexo = new List<SelectListItem>()
            {
                new SelectListItem 
                { 
                    Text = "Masculino",
                    Value = "Masculino"
                },
                new SelectListItem
                {
                    Text = "Feminino",
                    Value = "Feminino"
                }
            };

            var estado = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "RJ",
                    Value = "RJ"
                },
                new SelectListItem
                {
                    Text = "SP",
                    Value = "SP"
                }
            };

            ViewData["Sexo"] = sexo;
            ViewData["Estado"] = estado;

            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeViewModel homeViewModel)
        {
            if (!ModelState.IsValid)
            {
                var erros = string.Join("\n", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

                return Content(erros);
            }

            return Content("Sucesso");
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
    }
}
