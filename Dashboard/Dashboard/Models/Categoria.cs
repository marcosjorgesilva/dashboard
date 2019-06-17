using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produto = new HashSet<Produto>();
        }

        public int IdCategoria { get; set; }
        public string TipoCategoria { get; set; }

        public ICollection<Produto> Produto { get; set; }
    }
}
