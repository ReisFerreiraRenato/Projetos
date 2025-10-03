using System.IO;
using WpfApp.Models;
using WpfApp.Utils;

namespace WpfApp.Services
{
    public class ProdutoRepositry
    {
        private readonly string _caminhoArquivo = Constantes.CaminhoArquivoProduto;

        // 1. Obtem todos os produtos
        public async Task<List<Produto>> GetAllProdutosAsync()
        {
            if (!File.Exists(_caminhoArquivo))
                return [];
            
            var json = await File.ReadAllTextAsync(_caminhoArquivo);
            return System.Text.Json.JsonSerializer.Deserialize<List<Produto>>(json) ?? [];
        }

        // 2. Adiciona um novo produto a lista
        public async Task AddProdutoAsync(Produto produto)
        {
            var produtos = await GetAllProdutosAsync();
            int nextId = produtos.Count != 0 ? produtos.Max(p => p.Produto_Id) + 1 : 1;
            produto = new Produto
            {
                Produto_Id = nextId,
                Nome = produto.Nome,
                Valor = produto.Valor
            };
            produtos.Add(produto);
            
            var json = System.Text.Json.JsonSerializer.Serialize(produtos);
            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }

        // 3. Deleta um produto pelo ID
        public async Task DeleteProdutoAsync(int id)
        {
            var produtos = await GetAllProdutosAsync();
            var produto = produtos.FirstOrDefault(p => p.Produto_Id == id)
                ?? throw new InvalidOperationException(Constantes.ErroProdutoNaoEncontrado);
            produtos.Remove(produto);
            
            var json = System.Text.Json.JsonSerializer.Serialize(produtos);
            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }

        // 4. Atualiza um produto existente
        public async Task UpdateProdutoAsync(Produto produtoAtualizado)
        {
            var produtos = await GetAllProdutosAsync();
            var index = produtos.FindIndex(p => p.Produto_Id == produtoAtualizado.Produto_Id);
            
            if (index == -1)
                throw new InvalidOperationException(Constantes.ErroProdutoNaoEncontrado);
            produtos[index] = produtoAtualizado;

            var json = System.Text.Json.JsonSerializer.Serialize(produtos);
            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }

        // 5. Busca um produto pelo nome
        public async Task<Produto?> GetProdutoByNameAsync(string nome)
        {
            var produtos = await GetAllProdutosAsync();
            
            return produtos.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
    }
}