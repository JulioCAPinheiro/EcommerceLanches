using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using System.Diagnostics;
using Ecommerce.Repositories.Interfaces;
using Ecommerce.ViewModels;

namespace Site_em_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILanchesRepository _lancheRepository;

        public HomeController(ILanchesRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferido
            };

            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
