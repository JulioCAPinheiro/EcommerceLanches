using Ecommerce.Models;

namespace Ecommerce.Repositories.Interfaces
{
    public interface IPedidosRepository
    {
        void CriarPedido(Pedido pedido);
    }
}
