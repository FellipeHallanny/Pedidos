using System.Threading.Tasks;
using Pedidos.Domain;

namespace Pedidos.Application.Contratos
{
    public interface IPedidoService
    {
        Task<Pedido> AddPedidos(Pedido model);
        Task<Pedido> UpdatePedidos(int pedidoId, Pedido model);
        Task<bool> DeletePedidos(int pedidoId);

        Task<Pedido[]> GetAllPedidosAsync();      
        Task<Pedido> GetAllPedidoByIdAsync(int pedidoId);
    }
}