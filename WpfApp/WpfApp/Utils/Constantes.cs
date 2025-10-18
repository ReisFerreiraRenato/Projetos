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
        public const string ErroCPFInvalido = "CPF inválido.";
        public const string ErroPessoaNula = "Dados da pessoa nulo.";

        // Erros manipulacao produtos
        public const string ErroProdutoNaoEncontrado = "Produto não encontrado.";
        public const string ErroNomeProdutoObrigatorio = "Nome do produto é obrigatório.";
        public const string ErroPrecoProdutoInvalido = "Preço do produto deve ser maior que zero.";
        public const string ErroQuantidadeProdutoInvalida = "Quantidade do produto não pode ser negativa.";
        public const string ErroProdutoEmUso = "Produto está associado a um pedido e não pode ser removido.";
        public const string ErroDescricaoObrigatoria = "Descrição é obrigatória.";

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
        public const string ErroDataVendaInvalida = "Data da venda inválida.";

        // Erros manipulacao itens pedido
        public const string ErroItensPedidoNaoEncontrado = "Item do pedido não encontrado.";
        public const string ErroQuantidadeInvalida = "A quantidade deve ser maior que zero.";
        public const string ErroPrecoTotalItemInvalido = "O preço total do item deve ser maior que zero.";

        // Erros de ação
        public const string ErroAcaoExecucaoInvalida = "A ação de execução não pode ser nula.";

        // Erros de extensões
        public const string ErroTipoEnum = "O tipo fornecido deve ser um enum.";

        //Mensagens gerais
        public const string MensagemConfirmacaoSair = "Você tem certeza que deseja sair do aplicativo?";
        public const string TituloMensagemConfirmacaoSair = "Confirmação de Saída";
        public const string ErroRepositorioNaoIniciado = "_repository não foi inicializado.";
        public const string MesnsagemListaDeveEstarVazia = "A lista deve estar vazia quando o arquivo não existe.";
        public const string MensagemDeveRetornarDoisItens = "Deve retornar exatamente 2 itens.";
        public const string ErroCaminhoTesteNaoInicializado = "O caminho de teste não foi inicializado corretamente.";
    }
}
