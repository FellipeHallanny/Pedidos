using System.Collections.Generic;

namespace Pedidos.Domain.Commands.Response
{
    public class CreateStatusResponse
    {
        public int Pedido { get; set; }
        public List<string> Status { get; set; }

    }
}