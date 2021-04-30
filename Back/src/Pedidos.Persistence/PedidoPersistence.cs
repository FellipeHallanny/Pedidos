using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedidos.Domain;
using Pedidos.Persistence.Contextos;
using Pedidos.Persistence.Contratos;

namespace Pedidos.Persistence
{
    public class PedidoPersistence : IPedidoPersistence
    {
        private readonly PedidoContext _context;

        public PedidoPersistence(PedidoContext context)
        {
            _context = context;

        }
        public async Task<Pedido> GetAllPedidoByIdAsync(int pedidoId)
        {
            IQueryable<Pedido> query = _context.Pedidos
                            .Include(e => e.Itens);

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == pedidoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pedido[]> GetAllPedidosAsync()
        {
            IQueryable<Pedido> query = _context.Pedidos
                            .Include(e => e.Itens);

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
    }
}