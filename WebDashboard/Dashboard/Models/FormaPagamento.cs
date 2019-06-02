using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    public partial class FormaPagamento
    {
        public FormaPagamento()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdFormaPagamento { get; set; }
        public string DescricaoFp { get; set; }
        public string TipoFp { get; set; }

        public ICollection<Pedido> Pedido { get; set; }
    }
}
