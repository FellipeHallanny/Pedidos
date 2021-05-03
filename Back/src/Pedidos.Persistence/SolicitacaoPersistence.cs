using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedidos.Domain;
using Pedidos.Persistence.Contextos;
using Pedidos.Persistence.Contratos;

namespace Pedidos.Persistence
{
    public class SolicitacaoPersistence : ISolicitacaoPersistence
    {
        private readonly PedidoContext _context;

        public SolicitacaoPersistence(PedidoContext context)
        {
            _context = context;

        }
        public async Task<Solicitacao> GetAllSolicitacaoByIdAsync(int id)
        {
            IQueryable<Solicitacao> query = _context.Solicitacoes
                            .Include(e => e.Itens);

            query = query.AsNoTracking().OrderBy(e => e.Pedido).Where(e => e.Pedido == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Solicitacao[]> GetAllSolicitacoesAsync()
        {
            IQueryable<Solicitacao> query = _context.Solicitacoes
                            .Include(e => e.Itens);

            query = query.AsNoTracking().OrderBy(e => e.Pedido);

            return await query.ToArrayAsync();
        }
    }
}