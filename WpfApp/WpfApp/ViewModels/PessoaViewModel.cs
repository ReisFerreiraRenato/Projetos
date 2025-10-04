using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Models;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    public class PessoaViewModel(Pessoa pessoa) : INotifyPropertyChanged
    {
        private readonly Pessoa _pessoa = pessoa ?? throw new ArgumentNullException(nameof(pessoa), Constantes.ErroPessoaNula);

        // 1. Propriedades que refletem os campos do modelo Pessoa
        public int Pessoa_Id
        {
            get => _pessoa.Pessoa_Id;
        }

        public string Nome
        {
            get => _pessoa.Nome;
            set
            {
                if (_pessoa.Nome != value)
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException(Constantes.ErroNomeObrigatorio);

                    _pessoa.Nome = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CPF
        {
            get => _pessoa.CPF;
            set
            {
                if (_pessoa.CPF != value)
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException(Constantes.ErroCPFObrigatorio);
                    // Adicione aqui a validação de CPF se necessário
                    _pessoa.CPF = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Endereco
        {
            get => _pessoa.Endereco;
            set
            {
                if (_pessoa.Endereco != value)
                {
                    _pessoa.Endereco = value;
                    OnPropertyChanged();
                }
            }
        }

        // 2. Implementação do INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
