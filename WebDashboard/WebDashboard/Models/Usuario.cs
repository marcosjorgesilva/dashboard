using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDashboard.Models
{
    public partial class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }

        [ForeignKey("RefIdUsuario")]
        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

        public Usuario()
        {
        }

        public Usuario(int idUsuario, string tipoUsuario, string nomeUsuario, string login, string senha, string cpf, string email, DateTime dataNascimento, string telefoneFixo, string telefoneCelular)
        {
            IdUsuario = idUsuario;
            TipoUsuario = tipoUsuario;
            NomeUsuario = nomeUsuario;
            Login = login;
            Senha = senha;
            Cpf = cpf;
            Email = email;
            DataNascimento = dataNascimento;
            TelefoneFixo = telefoneFixo;
            TelefoneCelular = telefoneCelular;
        }

        public void AddEndereco(Endereco e)
        {
            Enderecos.Add(e);
        }

        public void RemoveEndereco(Endereco e)
        {
            Enderecos.Remove(e);
        }
    }
}
