using System;
using System.Threading.Tasks;
using Pedidos.Application.Contratos;
using Pedidos.Domain;
using Pedidos.Persistence.Contratos;

namespace Pedidos.Application
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly ISolicitacaoPersistence _solicitacaPersistence;

        public SolicitacaoService(IGeralPersistence geralPersistence, ISolicitacaoPersistence solicitacaPersistence)
        {
            _solicitacaPersistence = solicitacaPersistence;
            _geralPersistence = geralPersistence;

        }

        public async Task<Solicitacao> AddSolicitacoes(Solicitacao model)
        {
            try
            {
                _geralPersistence.Add<Solicitacao>(model);

                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _solicitacaPersistence.GetAllSolicitacaoByIdAsync(model.Pedido);
                }

                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Solicitacao> UpdateSolicitacao(int id, Solicitacao model)
        {
            try
            {
                var solicitacao = await _solicitacaPersistence.GetAllSolicitacaoByIdAsync(id);
                if(solicitacao == null) return null;

                model.Pedido = solicitacao.Pedido;

                _geralPersistence.Update(model);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _solicitacaPersistence.GetAllSolicitacaoByIdAsync(model.Pedido);
                }
                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSolicitaca(int id)
        {
            try
            {
                var solicitacao = await _solicitacaPersistence.GetAllSolicitacaoByIdAsync(id);
                if(solicitacao == null) throw new Exception("Solicitacao para delete não foi encontrado!");

                _geralPersistence.Delete<Solicitacao>(solicitacao);

                return await _geralPersistence.SaveChangesAsync();         
        

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Solicitacao> GetAllSolicitacaoByIdAsync(int id)
        {
            try
            {
                var solicitacao = await _solicitacaPersistence.GetAllSolicitacaoByIdAsync(id);
                if (solicitacao == null) return null;
                
                return solicitacao;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Solicitacao[]> GetAllSolicitacoesAsync()
        {
            try
            {
                var solicitacoes = await _solicitacaPersistence.GetAllSolicitacoesAsync();
                if (solicitacoes == null) return null;

                return solicitacoes;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
        
    }
}