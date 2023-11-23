using Ecommerce.Models;

namespace Ecommerce.Repositories.Interfaces
{
    public interface ILanchesRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferido { get; }
        Lanche GetLancheById(int lancheId);
    }
}
