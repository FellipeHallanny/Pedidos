using System.Collections.Generic;

namespace Pedidos.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public IEnumerable<Itens> Itens { get; set; }
    }
}