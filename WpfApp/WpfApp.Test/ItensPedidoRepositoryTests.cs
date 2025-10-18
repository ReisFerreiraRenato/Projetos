using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.Utils;
using System.Text.Json;

namespace WpfApp.Test
{
    [TestClass]
    public class ItensPedidoRepositoryTests
    {
        private readonly string? _caminhoTeste = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        private ItensPedidoRepository? _repository;

        [TestInitialize] // ATRIBUTO DO MSTEST
        public void Setup()
        {
            // 1. Instancia o repositório, passando o caminho de teste (requer a refatoração do Repositório)
            _repository = new ItensPedidoRepository(_caminhoTeste);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Garante que o arquivo temporário criado ou usado seja apagado
            if (File.Exists(_caminhoTeste))
            {
                File.Delete(_caminhoTeste);
            }
        }


        [TestMethod]
        public async Task GetAllItensPedidoAsync_QuandoArquivoNaoExiste_RetornaListaVazia()
        {
            // ARRANGE: Garantido pelo Cleanup e Setup

            // ACT
            var result = await (_repository ?? throw new AssertFailedException(Constantes.ErroRepositorioNaoIniciado)).GetAllItensPedidoAsync();

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count, Constantes.MesnsagemListaDeveEstarVazia);
        }

        [TestMethod]
        public async Task GetAllItensPedidoAsync_QuandoArquivoExisteComDados_RetornaDadosCorretos()
        {
            // ARRANGE

            if (string.IsNullOrWhiteSpace(_caminhoTeste))
            {
                throw new InvalidOperationException(Constantes.ErroCaminhoTesteNaoInicializado);
            }

            // 1. Crie dados de teste
            var itensDeTeste = new List<ItensPedido>
            {
                new() { ItemPedido_Id = 1, PedidoId = 1, ProdutoId = 1, Quantidade = 2, PrecoTotalItem = 20.59M },
                new() { ItemPedido_Id = 2, PedidoId = 1, ProdutoId = 2, Quantidade = 1, PrecoTotalItem = 10.37M }
            };

            // 2. Converta para JSON e escreva no arquivo de teste
            var json = JsonSerializer.Serialize(itensDeTeste);
            await File.WriteAllTextAsync(_caminhoTeste, json);

            // ACT
            var result = await (_repository ?? throw new AssertFailedException(Constantes.ErroRepositorioNaoIniciado)).GetAllItensPedidoAsync();

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count, Constantes.MensagemDeveRetornarDoisItens);

            // Verifique o primeiro item
            Assert.AreEqual(1, result[0].ItemPedido_Id);
            Assert.AreEqual(1, result[0].PedidoId);
            Assert.AreEqual(1, result[0].ProdutoId);
            Assert.AreEqual(2, result[0].Quantidade);
            Assert.AreEqual(20.59M, result[0].PrecoTotalItem);

            // Verifique o segundo item
            Assert.AreEqual(2, result[1].ItemPedido_Id);
            Assert.AreEqual(1, result[1].PedidoId);
            Assert.AreEqual(2, result[1].ProdutoId);
            Assert.AreEqual(1, result[1].Quantidade);
            Assert.AreEqual(10.37M, result[1].PrecoTotalItem);
        }
    }
}