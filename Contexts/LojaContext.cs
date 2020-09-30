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
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }
    }
}
