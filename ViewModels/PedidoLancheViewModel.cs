﻿using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class PedidoLancheViewModel
    {
        public Pedido Pedido { get; set; }

        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
