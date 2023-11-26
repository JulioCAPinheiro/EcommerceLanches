using Ecommerce.Models;
using Ecommerce.Repositories;
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

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lanchesRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                /*
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase ) || string.Equals("Natural", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lanchesRepository.Lanches
                     .Where(l => l.Categoria.CategoriaNome.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                     .OrderBy(l => l.Nome);
                }
                else
                {
                    return RedirectToAction("Index");
                }*/
                lanches = _lanchesRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals(categoria)).OrderBy(l => l.Nome);

                categoriaAtual = categoria;
            }

            

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriAtual = categoriaAtual,
            };

            return View(lanchesListViewModel);

        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lanchesRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }
    }
}
