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
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoService _solicitacaoService;

        public SolicitacaoController(ISolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;

        }


        [HttpGet("/api/pedido")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var solicitacao = await _solicitacaoService.GetAllSolicitacoesAsync();
                if (solicitacao == null) return NotFound("Nenhuma solicitação de pedido encontrada!");

                return Ok(solicitacao);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar recuperar solicitação de pedido. Erro: {ex.Message}");
            }
        }

        [HttpGet("/api/pedido/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var solicitacao = await _solicitacaoService.GetAllSolicitacaoByIdAsync(id);
                if (solicitacao == null) return NotFound("Solicitacaoção de pedido por Id não encontrado!");

                return Ok(solicitacao);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar recuperar solicitação de pedido. Erro: {ex.Message}");
            }
        }

        [HttpPost("/api/pedido")]
        public async Task<IActionResult> PostAsync(Solicitacao model)
        {            
            try
            {
                var solicitacao = await _solicitacaoService.AddSolicitacoes(model);
                if (solicitacao == null) return BadRequest("Erro ao tentar adicionar solicitação de pedido.");

                return Ok(solicitacao);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar adicionar solicitação de pedido. Erro: {ex.Message}");
            }
        }

        [HttpPut("/api/pedido/{id}")]
        public async Task<IActionResult> Put(int id, Solicitacao model)
        {
            try
            {
                var solicitacao = await _solicitacaoService.UpdateSolicitacao(id,model);
                if (solicitacao == null) return BadRequest("Erro ao tentar adicionar solicitação de pedido.");

                return Ok(solicitacao);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar atualizar solicitação de pedido. Erro: {ex.Message}");
            }
        }

        [HttpDelete("/api/pedido/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               return await _solicitacaoService.DeleteSolicitaca(id) ?
                   Ok("Deletado") :               
                   BadRequest("solicitação de pedido não deletado!");

            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                    $"Erro ao tentar deletar solicitação de pedido. Erro: {ex.Message}");
            }
        }

    }
}
