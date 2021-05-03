using System.ComponentModel.DataAnnotations;

namespace Pedidos.Domain.Commands.Requests
{
    public class CreateStatusRequest
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public double ValorAprovado { get; set; }
        public int Pedido { get; set; }

    }
}