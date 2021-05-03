using System.Threading.Tasks;
using Pedidos.Domain;

namespace Pedidos.Application.Contratos
{
    public interface ISolicitacaoService
    {
        Task<Solicitacao> AddSolicitacoes(Solicitacao model);
        Task<Solicitacao> UpdateSolicitacao(int id, Solicitacao model);
        Task<bool> DeleteSolicitaca(int id);

        Task<Solicitacao[]> GetAllSolicitacoesAsync();      
        Task<Solicitacao> GetAllSolicitacaoByIdAsync(int id);
    }
}