using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Domain
{
    public class Itens
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public int qtd { get; set; }

        [NotMapped]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}