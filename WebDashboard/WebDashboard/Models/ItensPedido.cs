using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDashboard.Models
{
    public partial class ItensPedido 
	{
        public int Quantidade { get; set; }
        public Double ValorTotal { get; set; }

        [Key]
        [Column(Order = 1)]
        public int RefIdIPedido { get; set; }
        public Pedido Pedido { get; set; }

        [Key]
        [Column(Order = 2)]
        public int RefIdProduto { get; set; }
        public Produto Produto { get; set; }
        
        public ItensPedido()
        {
        }

        public ItensPedido(int quantidade, double valorTotal, Pedido pedido, Produto produto)
        {
            Quantidade = quantidade;
            ValorTotal = valorTotal;
            Pedido = pedido;
            Produto = produto;
        }
    }
    
}
