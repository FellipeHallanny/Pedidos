using Microsoft.EntityFrameworkCore;
using Pedidos.Domain;

namespace Pedidos.Persistence.Contextos
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options)
        : base(options) {}

        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Itens> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}