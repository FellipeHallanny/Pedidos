using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.Domain
{
    public class Solicitacao
    {        
        [Key]
        public int Pedido { get; set; }
        public List<Itens> Itens { get; set; }
    }
}