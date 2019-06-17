using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Endereco = new HashSet<Endereco>();
            Pedido = new HashSet<Pedido>();
        }

        public int IdUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TelCelular { get; set; }
        public string TelFixo { get; set; }

        public ICollection<Endereco> Endereco { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
