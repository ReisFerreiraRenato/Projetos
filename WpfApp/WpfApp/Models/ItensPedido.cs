namespace WpfApp.Models
{
    public class ItensPedido
    {
        // 1. Id - int - chave primária da tabela ItemPedido Gerenciado Externamente
        public int ItemPedido_Id { get; init; }

        // 2. PedidoId - int - chave estrangeira referenciando a tabela Pedido (obrigatório)
        public int PedidoId { get; set; }

        // 3. ProdutoId - int - chave estrangeira referenciando a tabela Produto (obrigatório)
        public int ProdutoId { get; set; }

        // 4. Quantidade - int - quantidade do produto no pedido (obrigatório)
        public int Quantidade { get; set; }

        // 5. PrecoTotalItem - decimal - preço total do item no pedido (obrigatório)
        public decimal PrecoTotalItem { get; set; }
    }
}
