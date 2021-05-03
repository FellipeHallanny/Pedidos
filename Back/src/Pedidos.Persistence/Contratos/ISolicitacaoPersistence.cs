using System.Threading.Tasks;
using Pedidos.Domain;

namespace Pedidos.Persistence.Contratos
{
    public interface ISolicitacaoPersistence
    {
         Task<Solicitacao[]> GetAllSolicitacoesAsync();
         Task<Solicitacao> GetAllSolicitacaoByIdAsync(int id);
    }
}