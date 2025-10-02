namespace WpfApp.Models
{
    public class Produto
    {
        // 1. Id - int - chave primária da tabela Produto Gerenciado Externamente
        public int Produto_Id { get; init; }

        // 2. Nome - string - nome do produto (obrigatório)
        public string Nome { get; set; } = default!;

        // 3. Codigo - string - código do produto (obrigatório, único)
        public string Codigo { get; set; } = default!;

        // 4. Valor - decimal - valor do produto (obrigatório)
        public decimal Valor { get; set; }
    }
}
