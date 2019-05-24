using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDashboard.Models
{
    public class FormaPagamento
    {	
        [Key]
        public int IdCategoria { get; set; }
        public string TipoCategoria { get; set; }

        [ForeignKey("RefIdFormaPagamento")]
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
   
        public FormaPagamento()
        {
        }

        public FormaPagamento(int idCategoria, string tipoCategoria)
        {
            IdCategoria = idCategoria;
            TipoCategoria = tipoCategoria;
        }

        public void AddPedido(Pedido p)
        {
            Pedidos.Add(p);
        }

        public void RemovePedido(Pedido p)
        {
            Pedidos.Remove(p);
        }
    }
}
