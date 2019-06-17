using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public int IdFormaPagamento { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double ValorPedido { get; set; }

        public FormaPagamento IdFormaPagamentoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
