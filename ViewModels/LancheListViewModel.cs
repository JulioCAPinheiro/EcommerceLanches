using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriAtual { get; set; }



    }
}
