namespace Pedidos.Domain
{
    public class Itens
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public int qtd { get; set; }

        public int SolicitacaoPedido { get; set; }
        public Solicitacao Solicitacao { get; set; }
    }
}