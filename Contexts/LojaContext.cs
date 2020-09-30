using Microsoft.EntityFrameworkCore;
using ORM_API_Loja.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM_API_Loja.Contexts
{
    public class LojaContext : DbContext
    {
        //Os DbSets representam as tabelas que serão construídas no banco.
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }

        /// <summary>
        /// Cria um banco de dados de acordo com os DbSets acima, que se referem às classes na pasta Domains.
        /// </summary>
        /// <param name="optionsBuilder">Objeto no formato DbContextOptionsBuilder, usado para configurar bancos de dados.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=THIAGO-PC\SQLEXPRESS; Initial Catalog=Loja; user id=sa; password=sa132");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
