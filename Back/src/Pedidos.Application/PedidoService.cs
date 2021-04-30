using System;
using System.Threading.Tasks;
using Pedidos.Application.Contratos;
using Pedidos.Domain;
using Pedidos.Persistence.Contratos;

namespace Pedidos.Application
{
    public class PedidoService : IPedidoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IPedidoPersistence _pedidoPersistence;

        public PedidoService(IGeralPersistence geralPersistence, IPedidoPersistence pedidoPersistence)
        {
            _pedidoPersistence = pedidoPersistence;
            _geralPersistence = geralPersistence;

        }

        public async Task<Pedido> AddPedidos(Pedido model)
        {
            try
            {
                _geralPersistence.Add<Pedido>(model);

                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _pedidoPersistence.GetAllPedidoByIdAsync(model.Id);
                }

                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> UpdatePedidos(int pedidoId, Pedido model)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetAllPedidoByIdAsync(pedidoId);
                if(pedido == null) return null;

                model.Id = pedido.Id;

                _geralPersistence.Update(model);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _pedidoPersistence.GetAllPedidoByIdAsync(model.Id);
                }
                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePedidos(int pedidoId)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetAllPedidoByIdAsync(pedidoId);
                if(pedido == null) throw new Exception("Pedido para delete não foi encontrado!");

                _geralPersistence.Delete<Pedido>(pedido);

                return await _geralPersistence.SaveChangesAsync();         
        

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> GetAllPedidoByIdAsync(int pedidoId)
        {
            try
            {
                var pedido = await _pedidoPersistence.GetAllPedidoByIdAsync(pedidoId);
                if (pedido == null) return null;
                
                return pedido;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido[]> GetAllPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoPersistence.GetAllPedidosAsync();
                if (pedidos == null) return null;

                return pedidos;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
        
    }
}