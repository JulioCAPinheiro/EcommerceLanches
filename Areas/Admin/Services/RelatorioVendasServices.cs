using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Areas.Admin.Services
{
    public class RelatorioVendasServices
    {
        private readonly AppDbContext context;

        public RelatorioVendasServices(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Pedido>> FindByDataAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedido select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= maxDate.Value);
            }

            return await resultado
                .Include(l => l.PedidoItens)
                .ThenInclude(l => l.Lanche)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
        }
    }
}
