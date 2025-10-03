namespace WpfApp.Models
{
    public class Pessoa
    {
        // 1. Id - int - chave primária da tabela Pessoa Gerenciado Externamente
        public int Pessoa_Id { get; init; }

        // 2. Nome - string - nome da pessoa (obrigatório)
        public string Nome { get; set; } = default!;

        // 3. CPF - string - CPF da pessoa (obrigatório, único)
        public string CPF { get; set; } = default!;

        // 4. Endereco - string - endereço da pessoa (opcional)
        public string? Endereco { get; set; }
    }
}
