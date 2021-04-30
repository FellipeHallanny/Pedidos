using System.Threading.Tasks;
using Pedidos.Domain;

namespace Pedidos.Persistence.Contratos
{
    public interface IPedidoPersistence
    {
         Task<Pedido[]> GetAllPedidosAsync();
         Task<Pedido> GetAllPedidoByIdAsync(int pedidoId);
    }
}