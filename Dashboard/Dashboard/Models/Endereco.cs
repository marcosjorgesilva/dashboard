using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    public partial class Endereco
    {
        public int IdEndereco { get; set; }
        public int IdUsuario { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
    }
}
