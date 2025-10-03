using System.IO;
using WpfApp.Models;
using WpfApp.Utils;

namespace WpfApp.Services
{
    public class PedidoRepository
    {
        private readonly string _caminhoArquivo = Constantes.CaminhoArquivoPedido;
        
        // 1. Obtem todos os pedidos
        public async Task<List<Pedido>> GetAllPedidosAsync()
        {
            if (!File.Exists(_caminhoArquivo))
                return [];
            var json = await File.ReadAllTextAsync(_caminhoArquivo);
            return System.Text.Json.JsonSerializer.Deserialize<List<Pedido>>(json) ?? [];
        }
        
        // 2. Adiciona um novo pedido a lista
        public async Task AddPedidoAsync(Pedido pedido)
        {
            var pedidos = await GetAllPedidosAsync();
            int nextId = pedidos.Count != 0 ? pedidos.Max(p => p.Pedido_Id) + 1 : 1;
            
            pedido = new Pedido
            {
                Pedido_Id = nextId,
                PessoaId = pedido.PessoaId,
                ItensPedido = pedido.ItensPedido,
                ValorTotal = pedido.ValorTotal,
                DataVenda = pedido.DataVenda,
                Status = pedido.Status,
                FormaPagamento = pedido.FormaPagamento
            };
            pedidos.Add(pedido);

            var json = System.Text.Json.JsonSerializer.Serialize(pedidos);
            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }

        // 3. Deleta um pedido pelo ID
        public async Task DeletePedidoAsync(int id)
        {
            var pedidos = await GetAllPedidosAsync();
            var pedido = pedidos.FirstOrDefault(p => p.Pedido_Id == id)
                ?? throw new InvalidOperationException(Constantes.ErroPedidoNaoEncontrado);
            pedidos.Remove(pedido);
            
            var json = System.Text.Json.JsonSerializer.Serialize(pedidos);
            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }
        
        // 4. Atualiza um pedido existente
        public async Task UpdatePedidoAsync(Pedido pedidoAtualizado)
        {
            var pedidos = await GetAllPedidosAsync();
            var index = pedidos.FindIndex(p => p.Pedido_Id == pedidoAtualizado.Pedido_Id);
            if (index == -1)
                throw new InvalidOperationException(Constantes.ErroPedidoNaoEncontrado);
            pedidos[index] = pedidoAtualizado;
            
            var json = System.Text.Json.JsonSerializer.Serialize(pedidos);
            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }

        // 5. Obtem um pedido pelo ID
        public async Task<Pedido> GetPedidoByIdAsync(int id)
        {
            var pedidos = await GetAllPedidosAsync();
            var pedido = pedidos.FirstOrDefault(p => p.Pedido_Id == id)
                ?? throw new InvalidOperationException(Constantes.ErroPedidoNaoEncontrado);
            
            return pedido;
        }

        // 6. Obtem todos os pedidos de uma pessoa pelo ID da pessoa
        public async Task<List<Pedido>> GetPedidosByPessoaIdAsync(int pessoaId)
        {
            var pedidos = await GetAllPedidosAsync();
            
            return [.. pedidos.Where(p => p.PessoaId == pessoaId)];
        }
    }
}
