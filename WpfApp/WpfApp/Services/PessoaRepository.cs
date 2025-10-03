using System.IO;
using WpfApp.Models;
using WpfApp.Utils;


namespace WpfApp.Services
{
    public class PessoaRepository
    {
        private readonly string _caminhoArquivo = Constantes.CaminhoArquivoPessoa;
        
        // 1. Obtem todas as pessoas
        public async Task<List<Pessoa>> GetAllPessoasAsync()
        {
            if (!File.Exists(_caminhoArquivo))
                return [];

            var json = await File.ReadAllTextAsync(_caminhoArquivo);
            
            return System.Text.Json.JsonSerializer.Deserialize<List<Pessoa>>(json) ?? [];
        }

        // 2. Adiciona uma nova pessoa a lista
        public async Task AddPessoaAsync(Pessoa pessoa)
        {
            var pessoas = await GetAllPessoasAsync();
            
            if (pessoas.Any(p => p.CPF == pessoa.CPF))
                throw new InvalidOperationException(Constantes.ErroCPFJaCadastrado);
            
            int nextId = pessoas.Count != 0 ? pessoas.Max(p => p.Pessoa_Id) + 1 : 1;
            
            pessoa = new Pessoa
            {
                Pessoa_Id = nextId,
                Nome = pessoa.Nome,
                CPF = pessoa.CPF,
                Endereco = pessoa.Endereco
            };
            pessoas.Add(pessoa);
            
            var json = System.Text.Json.JsonSerializer.Serialize(pessoas);
            
            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }

        // 3. Deleta uma pessoa pelo ID
        public async Task DeletePessoaAsync(int id)
        {
            var pessoas = await GetAllPessoasAsync();
            var pessoa = pessoas.FirstOrDefault(p => p.Pessoa_Id == id) 
                ?? throw new InvalidOperationException(Constantes.ErroPessoaNaoEncontrada);
            pessoas.Remove(pessoa);

            var json = System.Text.Json.JsonSerializer.Serialize(pessoas);

            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }

        // 4. Atualiza uma pessoa existente
        public async Task AtualizaPessoaAsync(Pessoa pessoa)
        {
            var pessoas = await GetAllPessoasAsync();
            
            var existingPessoa = pessoas.FirstOrDefault(p => p.Pessoa_Id == pessoa.Pessoa_Id)
                    ?? throw new InvalidOperationException(Constantes.ErroPessoaNaoEncontrada);
            
            if (pessoas.Any(p => p.CPF == pessoa.CPF && p.Pessoa_Id != pessoa.Pessoa_Id))
                throw new InvalidOperationException(Constantes.ErroCPFJaCadastrado);
            
            existingPessoa.Nome = pessoa.Nome;
            existingPessoa.CPF = pessoa.CPF;
            existingPessoa.Endereco = pessoa.Endereco;
            
            var json = System.Text.Json.JsonSerializer.Serialize(pessoas);
            
            await File.WriteAllTextAsync(_caminhoArquivo, json);
        }

        // 5. Obtem uma pessoa pelo ID
        public async Task<Pessoa?> GetPessoaByIdAsync(int id)
        {
            var pessoas = await GetAllPessoasAsync();
            
            return pessoas.FirstOrDefault(p => p.Pessoa_Id == id);
        }

        // 6. Obtem uma pessoa pelo CPF
        public async Task<Pessoa?> GetPessoaByCPFAsync(string cpf)
        {
            var pessoas = await GetAllPessoasAsync();

            return pessoas.FirstOrDefault(p => p.CPF == cpf);
        }

    }
}
