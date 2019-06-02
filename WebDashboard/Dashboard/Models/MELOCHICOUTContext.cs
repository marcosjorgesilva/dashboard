using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dashboard.Models
{
    public partial class MELOCHICOUTContext : DbContext
    {
        public MELOCHICOUTContext()
        {
        }

        public MELOCHICOUTContext(DbContextOptions<MELOCHICOUTContext> options)
       : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        // Unable to generate entity type for table 'dbo.itensPedido'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;User Id=dbomarcos;Password=#marcos;Database=MELOCHICOUT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.TipoCategoria)
                    .IsRequired()
                    .HasColumnName("tipo_categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco);

                entity.ToTable("endereco");

                entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep).HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("char(2)");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("logradouro")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Referencia)
                    .HasColumnName("referencia")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__endereco__id_usu__4316F928");
            });

            modelBuilder.Entity<FormaPagamento>(entity =>
            {
                entity.HasKey(e => e.IdFormaPagamento);

                entity.ToTable("formaPagamento");

                entity.Property(e => e.IdFormaPagamento).HasColumnName("id_formaPagamento");

                entity.Property(e => e.DescricaoFp)
                    .IsRequired()
                    .HasColumnName("descricao_fp")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoFp)
                    .IsRequired()
                    .HasColumnName("tipo_fp")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.ToTable("pedido");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.DataEntrega)
                    .HasColumnName("data_entrega")
                    .HasColumnType("date");

                entity.Property(e => e.DataPedido)
                    .HasColumnName("data_pedido")
                    .HasColumnType("date");

                entity.Property(e => e.IdFormaPagamento).HasColumnName("id_formaPagamento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.ValorPedido).HasColumnName("valor_pedido");

                entity.HasOne(d => d.IdFormaPagamentoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedido__id_forma__48CFD27E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedido__id_usuar__47DBAE45");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto);

                entity.ToTable("produto");

                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.Estoque).HasColumnName("estoque");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Tamanho)
                    .HasColumnName("tamanho")
                    .HasColumnType("char(3)");

                entity.Property(e => e.ValorProduto).HasColumnName("valor_produto");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__produto__id_cate__4E88ABD4");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__usuario__D836E71F4FEEEF9A")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__usuario__AB6E616443804204")
                    .IsUnique();

                entity.HasIndex(e => e.Login)
                    .HasName("UQ__usuario__7838F27256A75756")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("data_nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelCelular)
                    .IsRequired()
                    .HasColumnName("tel_celular")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.TelFixo)
                    .HasColumnName("tel_fixo")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("tipo_usuario")
                    .HasColumnType("char(3)");
            });
        }
    }
}
