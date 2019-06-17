using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    public partial class Produto
    {
        public int IdProduto { get; set; }
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public double ValorProduto { get; set; }
        public int Estoque { get; set; }
        public string Tamanho { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
    }
}
