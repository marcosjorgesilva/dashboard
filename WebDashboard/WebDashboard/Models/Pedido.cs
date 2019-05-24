using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDashboard.Models
{
    public partial class Pedido 
	{
        [Key]
        public int IdPedido { get; set; }
        public string Nome { get; set; }
        public double ValorProduto { get; set; }
        public int Estoque { get; set; }
        public string Tamanho { get; set; }

        public int RefIdFormaPagamento { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        [ForeignKey("RefIdIPedido")]
        public ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();

        public Pedido()
        {
        }

        public Pedido(int idPedido, string nome, double valorProduto, int estoque, string tamanho, FormaPagamento formaPagamento)
        {
            IdPedido = idPedido;
            Nome = nome;
            ValorProduto = valorProduto;
            Estoque = estoque;
            Tamanho = tamanho;
            FormaPagamento = formaPagamento;
        }

        public void AddItensPedido(ItensPedido ip)
        {
            ItensPedidos.Add(ip);
        }

        public void RemoveItensPedido(ItensPedido ip)
        {
            ItensPedidos.Remove(ip);
        }

    }
    
}
