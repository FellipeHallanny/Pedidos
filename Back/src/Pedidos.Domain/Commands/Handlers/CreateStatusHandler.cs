using Pedidos.Domain.Commands.Handlers.Contratos;
using Pedidos.Domain.Commands.Requests;
using Pedidos.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos.Domain.Commands.Handlers
{
    public class CreateStatusHandler : ICreateStatusHandler
    {


        public CreateStatusResponse Handle(CreateStatusRequest request, Solicitacao pedido)
        {
            //Regras
            return ValidarPedido(request, pedido);
        }

        private CreateStatusResponse ValidarPedido(CreateStatusRequest request, Solicitacao pedido)
        {
            List<string> statusList = new List<string>();
            int quantidadeItens = 0;
            double valorTotalPedido = 0;

           

            if (request.Status.ToUpper().Equals("REPROVADO"))
            {
                statusList.Add("REPROVADO");
                return new CreateStatusResponse() { Pedido = pedido.Pedido, Status = statusList };
            }                


            pedido.Itens.ForEach(x => quantidadeItens += x.qtd);
            pedido.Itens.ForEach(x => valorTotalPedido += x.PrecoUnitario * x.qtd);

            if (request.ItensAprovados == quantidadeItens && request.ValorAprovado == valorTotalPedido)
            {
                statusList.Add("APROVADO");
                return new CreateStatusResponse() { Pedido = pedido.Pedido, Status = statusList };
            }
                

            if (request.ValorAprovado < valorTotalPedido)
                statusList.Add("APROVADO_VALOR_A_MENOR");

            if (request.ItensAprovados < quantidadeItens)
                statusList.Add("APROVADO_QTD_A_MENOR");

            if (request.ValorAprovado > valorTotalPedido)
                statusList.Add("APROVADO_VALOR_A_MAIOR");

            if (request.ItensAprovados > quantidadeItens)
                statusList.Add("APROVADO_QTD_A_MAIOR");




            return new CreateStatusResponse() { Pedido = pedido.Pedido, Status = statusList };
        }
    }
}