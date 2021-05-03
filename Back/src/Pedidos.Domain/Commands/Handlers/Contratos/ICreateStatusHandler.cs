using Pedidos.Domain.Commands.Requests;
using Pedidos.Domain.Commands.Response;

namespace Pedidos.Domain.Commands.Handlers.Contratos
{
    public interface ICreateStatusHandler
    {
          CreateStatusResponse Handle(CreateStatusRequest request, Solicitacao pedido);
    }
}