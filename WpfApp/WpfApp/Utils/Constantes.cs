namespace WpfApp.Utils
{
    public static class Constantes 
    {
        // Caminho dos Arquivos JSON
        // Caminho Arquivo Pessoa
        public const string CaminhoArquivoPessoa = "pessoas.json";
        // Caminho Arquivo Produto
        public const string CaminhoArquivoProduto = "produtos.json";
        // Caminho Arquivo Pedido
        public const string CaminhoArquivoPedido = "pedidos.json";
        // Caminho Arquivo ItemPedido
        public const string CaminhoArquivoItensPedido = "itenspedido.json";

        // Erros manipulacao pessoas
        public const string ErroPessoaNaoEncontrada = "Pessoa não encontrada.";
        public const string ErroCPFJaCadastrado = "CPF já cadastrado.";
        public const string ErroNomeObrigatorio = "Nome é obrigatório.";
        public const string ErroCPFObrigatorio = "CPF é obrigatório.";

        // Erros manipulacao produtos
        public const string ErroProdutoNaoEncontrado = "Produto não encontrado.";
        public const string ErroNomeProdutoObrigatorio = "Nome do produto é obrigatório.";
        public const string ErroPrecoProdutoInvalido = "Preço do produto deve ser maior que zero.";
        public const string ErroQuantidadeProdutoInvalida = "Quantidade do produto não pode ser negativa.";
        public const string ErroProdutoEmUso = "Produto está associado a um pedido e não pode ser removido.";

        //public const string ErroEstoqueInsuficiente = "Estoque insuficiente para o produto.";
        //public const string ErroAtualizacaoEstoqueProduto = "Não foi possível atualizar o estoque do produto.";

        // Erros manipulacao pedidos
        public const string ErroPedidoNaoEncontrado = "Pedido não encontrado.";
        public const string ErroPessoaInexistente = "Pessoa associada ao pedido não existe.";
        public const string ErroItensPedidoObrigatorios = "Um pedido deve conter pelo menos um item.";
        public const string ErroQuantidadeItemInvalida = "A quantidade do item deve ser maior que zero.";
        public const string ErroProdutoInexistente = "Produto associado ao item do pedido não existe.";
        public const string ErroValorTotalInvalido = "O valor total do pedido deve ser maior que zero.";
        public const string ErroAtualizacaoStatusInvalida = "Atualização de status inválida.";
        public const string ErroRemocaoPedidoComStatusFinalizado = "Pedidos finalizados ou cancelados não podem ser removidos.";
        public const string ErroAtualizacaoPedidoComStatusFinalizado = "Pedidos finalizados ou cancelados não podem ser atualizados.";
        
    }
}
