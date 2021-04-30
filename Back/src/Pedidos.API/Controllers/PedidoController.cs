using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.Application.Contratos;
using Pedidos.Domain;

namespace Pedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;

        }


        [HttpGet("/api/pedido")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var pedidos = await _pedidoService.GetAllPedidosAsync();
                if (pedidos == null) return NotFound("Nenhum pedido encontrado!");

                return Ok(pedidos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar recuperar pedidos. Erro: {ex.Message}");
            }
        }

        [HttpGet("/api/pedido/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var pedido = await _pedidoService.GetAllPedidoByIdAsync(id);
                if (pedido == null) return NotFound("pedido por Id não encontrado!");

                return Ok(pedido);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar recuperar pedido. Erro: {ex.Message}");
            }
        }

        [HttpPost("/api/pedido")]
        public async Task<IActionResult> PostAsync(Pedido model)
        {
            try
            {
                var pedido = await _pedidoService.AddPedidos(model);
                if (pedido == null) return BadRequest("Erro ao tentar adicionar pedido.");

                return Ok(pedido);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar adicionar pedido. Erro: {ex.Message}");
            }
        }

        [HttpPut("/api/pedido/{id}")]
        public async Task<IActionResult> Put(int id, Pedido model)
        {
            try
            {
                var pedido = await _pedidoService.UpdatePedidos(id,model);
                if (pedido == null) return BadRequest("Erro ao tentar adicionar pedido.");

                return Ok(pedido);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar atualizar pedido. Erro: {ex.Message}");
            }
        }

        [HttpDelete("/api/pedido/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               return await _pedidoService.DeletePedidos(id) ?
                   Ok("Deletado") :               
                   BadRequest("pedido não deletado!");

            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar deletar pedido. Erro: {ex.Message}");
            }
        }

    }
}
