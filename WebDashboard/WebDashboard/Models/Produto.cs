using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDashboard.Models
{
    public partial class Produto 
	{
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public double ValorProduto { get; set; }
        public int Estoque { get; set; }
        public string Tamanho { get; set; }

        public int RefIdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        [ForeignKey("RefIdProdutos")]
        public ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();

        public Produto()
        {
        }

        public Produto(int idProduto, string nome, double valorProduto, int estoque, string tamanho, Categoria categoria)
        {
            IdProduto = idProduto;
            Nome = nome;
            ValorProduto = valorProduto;
            Estoque = estoque;
            Tamanho = tamanho;
            Categoria = categoria;
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
