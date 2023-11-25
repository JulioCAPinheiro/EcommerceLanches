using Ecommerce.Repositories.Interfaces;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchesRepository _lanchesRepository;

        public LancheController(ILanchesRepository lanchesRepository)
        {
            _lanchesRepository = lanchesRepository;
        }

        public IActionResult List()
        {
            /*
            var lanches = _lanchesRepository.Lanches;
            return View(lanches);
            */

            var lanchesListViewModel = new LancheListViewModel();

            lanchesListViewModel.Lanches = _lanchesRepository.Lanches;
            lanchesListViewModel.CategoriAtual = "Categoria Atual";

            return View(lanchesListViewModel);

        }
    }
}
