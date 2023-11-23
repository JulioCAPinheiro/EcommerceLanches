using Ecommerce.Context;
using Ecommerce.Models;
using Ecommerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class LanchesRepository : ILanchesRepository
    {
        private readonly AppDbContext _context;

        public LanchesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(C => C.Categoria);
        public IEnumerable<Lanche> LanchesPreferido => 
            _context.Lanches.
            Where(l => l.IsLanchePReferido).
            Include(c => c.Categoria);
        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
