using WpfApp.Models;
using WpfApp.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;  

namespace WpfApp.ViewModels
{
    public class ProdutoViewModel(Produto produto) : INotifyPropertyChanged
    {
        private readonly Produto _produto = produto ?? throw new ArgumentNullException(nameof(produto), Constantes.ErroProdutoNaoEncontrado);

        // 1. Propriedades de acesso os campos do modelo Produto
        public int Produto_Id
        {
            get => _produto.Produto_Id;
        }

        public string Nome
        {
            get => _produto.Nome;
            set
            {
                if (_produto.Nome != value)
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException(Constantes.ErroNomeProdutoObrigatorio);
                    _produto.Nome = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Valor
        {
            get => _produto.Valor;
            set
            {
                if (_produto.Valor != value)
                {
                    if (value <= 0)
                        throw new ArgumentException(Constantes.ErroPrecoProdutoInvalido);
                    _produto.Valor = value;
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
