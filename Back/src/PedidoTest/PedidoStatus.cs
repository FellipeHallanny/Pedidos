using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos.Domain;
using Pedidos.Domain.Commands.Handlers;
using Pedidos.Domain.Commands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTest
{
    [TestClass()]
    public class PedidoStatus
    {
        [TestMethod()]
        public void ValidarReprovado()
        {
            var request = new CreateStatusRequest() { 
                Pedido = 1,
                Status = "REPROVADO"               
            
            };

            var itenA = new Itens() { Id = 1,Descricao = "Item A", PrecoUnitario = 5, qtd = 2};
            var itenB = new Itens() { Id = 2, Descricao = "Item B", PrecoUnitario = 10, qtd = 1 };

            var lista = new List<Itens>();
            lista.Add(itenA);
            lista.Add(itenB);

            var pedido = new Solicitacao() { 
                Pedido = 1,
                Itens = lista
            };

            var resposta = new CreateStatusHandler().Handle(request, pedido);
            Assert.IsTrue(resposta.Status[0].Equals("REPROVADO"));
        }


        [TestMethod()]
        public void ValidarAprovado()
        {
            var request = new CreateStatusRequest()
            {
                Pedido = 1,
                Status = "APROVADO",
                ItensAprovados = 3,
                ValorAprovado = 20

            };

            var itenA = new Itens() { Id = 1, Descricao = "Item A", PrecoUnitario = 5, qtd = 2 };
            var itenB = new Itens() { Id = 2, Descricao = "Item B", PrecoUnitario = 10, qtd = 1 };

            var lista = new List<Itens>();
            lista.Add(itenA);
            lista.Add(itenB);

            var pedido = new Solicitacao()
            {
                Pedido = 1,
                Itens = lista
            };

            var resposta = new CreateStatusHandler().Handle(request, pedido);
            Assert.IsTrue(resposta.Status[0].Equals("APROVADO"));
        }

        [TestMethod()]
        public void ValidarQtdItensMenor()
        {
            var request = new CreateStatusRequest()
            {
                Pedido = 1,
                Status = "APROVADO",
                ItensAprovados = 2,
                ValorAprovado = 20

            };

            var itenA = new Itens() { Id = 1, Descricao = "Item A", PrecoUnitario = 5, qtd = 2 };
            var itenB = new Itens() { Id = 2, Descricao = "Item B", PrecoUnitario = 10, qtd = 1 };

            var lista = new List<Itens>();
            lista.Add(itenA);
            lista.Add(itenB);

            var pedido = new Solicitacao()
            {
                Pedido = 1,
                Itens = lista
            };

            var resposta = new CreateStatusHandler().Handle(request, pedido);
            Assert.IsTrue(resposta.Status[0].Equals("APROVADO_QTD_A_MENOR"));
        }
    }
}