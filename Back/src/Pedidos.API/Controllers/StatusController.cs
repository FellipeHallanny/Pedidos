using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Contratos;
using Pedidos.Domain.Commands.Handlers.Contratos;
using Pedidos.Domain.Commands.Requests;
using Pedidos.Domain.Commands.Response;
using System;   
using System.Collections.Generic;

namespace Pedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ISolicitacaoService _pedidoService;

        public StatusController(ISolicitacaoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("/api/status")]
        public IActionResult ValidarPedido(
            [FromServices]ICreateStatusHandler handler,
            [FromBody]CreateStatusRequest command)
        {
            
            try
            {
                var pedido = _pedidoService.GetAllSolicitacaoByIdAsync(command.Pedido);

                if (pedido.Result == null)
                {
                    List<string> statusList = new List<string>();
                    statusList.Add("CODIGO_PEDIDO_INVALIDO");
                    return NotFound(new CreateStatusResponse() { Status = statusList });
                }
                    

                var retorno = handler.Handle(command, pedido.Result);
                return Ok(retorno);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar verificar status. Erro: {ex.Message}");
            }
            
        }
    }
}