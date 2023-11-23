using Ecommerce.Context;
using Ecommerce.Models;
using Ecommerce.Repositories.Interfaces;

namespace Ecommerce.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
