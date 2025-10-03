using System.IO;
using WpfApp.Models;
using WpfApp.Utils;

namespace WpfApp.Services
{
    public class ItensPedidoRepository
    {
        private readonly string _caminhoArquivo = Constantes.CaminhoArquivoItensPedido;

        // 1. Obtem todos os itens do pedido
        public async Task<List<ItensPedido>> GetAllItensPedidoAsync()
        {
            if (!File.Exists(_caminhoArquivo))
                return [];
            ;

            var json = await File.ReadAllTextAsync(_caminhoArquivo);
            return System.Text.Json.JsonSerializer.Deserialize<List<ItensPedido>>(json) ?? [];
        }
    }
}
