using WpfApp.Models;
using WpfApp.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.ViewModels
{
    public class ItensPedidoViewModel(ItensPedido itenspedido) : ViewModelBase
    {
        private readonly ItensPedido _itenspedido = itenspedido ?? throw new ArgumentNullException(nameof(itenspedido), Constantes.ErroPessoaNula);

        // 1. Propriedades que acessam os campos do modelo ItensPedido
        public int ItensPedido_Id
        {
            get => _itenspedido.ItemPedido_Id;
        }

        public int PedidoId
        {
            get => _itenspedido.PedidoId;
            set
            {
                if (_itenspedido.PedidoId != value)
                {
                    _itenspedido.PedidoId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ProdutoId
        {
            get => _itenspedido.ProdutoId;
            set
            {
                if (_itenspedido.ProdutoId != value)
                {
                    _itenspedido.ProdutoId = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Quantidade
        {
            get => _itenspedido.Quantidade;
            set
            {
                if (_itenspedido.Quantidade != value)
                {
                    if (value <= 0)
                        throw new ArgumentException(Constantes.ErroQuantidadeInvalida);
                    _itenspedido.Quantidade = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal PrecoTotalItem
        {
            get => _itenspedido.PrecoTotalItem;
            set
            {
                if (_itenspedido.PrecoTotalItem != value)
                {
                    if (value < 0)
                        throw new ArgumentException(Constantes.ErroPrecoTotalItemInvalido);
                    _itenspedido.PrecoTotalItem = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
