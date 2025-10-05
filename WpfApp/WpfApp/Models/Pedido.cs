using System.Collections.ObjectModel;
using WpfApp.Utils;

namespace WpfApp.Models
{
    public class Pedido
    {
        // 1. Id - int - chave primária da tabela Pedido Gerenciado Externamente
        public int Pedido_Id { get; init; }

        // 2. PessoaId - int - chave estrangeira referenciando a tabela Pessoa (obrigatório)
        public int PessoaId { get; set; }

        // Prpriedade de navegação para Pessoa
        public Pessoa? Pessoa { get; set; } = default!;

        // 3. Produtos - Lista de ItenmPedido - lista de produtos associados ao pedido (obrigatório)
        public ObservableCollection<ItensPedido> ItensPedido { get; set; } = [];

        // 4. ValorTotal - decimal - valor total do pedido (obrigatório)
        public decimal ValorTotal { get; set; }

        // 5. DataVenda - DateTime - data e hora do pedido (obrigatório)
        public DateTime DataVenda { get; set; }

        // 6. FormaPagamento - enum - forma de pagamento do pedido (obrigatório)
        public FormaPagamento FormaPagamento { get; set; }

        // 7. Status - enum - status do pedido (obrigatório, padrão: Pendente)
        public StatusPedido Status { get; set; } = StatusPedido.Pendente;

    }
}
