using WpfApp.Models;
using WpfApp.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.ViewModels
{
    public class PedidoViewModels(Pedido pedido) : INotifyPropertyChanged
    {
        private readonly Pedido _pedido = pedido ?? throw new ArgumentNullException(nameof(pedido), Constantes.ErroPedidoNaoEncontrado);

        // 1. Propriedades que refletem os campos do modelo Pedido
        public int Pedido_Id
        {
            get => _pedido.Pedido_Id;
        }

        public int PessoaId
        {
            get => _pedido.PessoaId;
            set
            {
                if (_pedido.PessoaId != value)
                {
                    if (value <= 0)
                        throw new ArgumentException(Constantes.ErroPessoaNaoEncontrada);
                    _pedido.PessoaId = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<ItensPedido> ItensPedido
        {
            get => _pedido.ItensPedido;
            set
            {
                if (_pedido.ItensPedido != value)
                {
                    if (value == null || value.Count == 0)
                        throw new ArgumentException(Constantes.ErroItensPedidoObrigatorios);
                    _pedido.ItensPedido = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal ValorTotal
        {
            get => _pedido.ValorTotal;
            set
            {
                if (_pedido.ValorTotal != value)
                {
                    if (value < 0)
                        throw new ArgumentException(Constantes.ErroValorTotalInvalido);
                    _pedido.ValorTotal = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime DataVenda
        {
            get => _pedido.DataVenda;
            set
            {
                if (_pedido.DataVenda != value)
                {
                    if (value > DateTime.Now)
                        throw new ArgumentException(Constantes.ErroDataVendaInvalida);
                    _pedido.DataVenda = value;
                    OnPropertyChanged();
                }
            }
        }

        public FormaPagamento FormaPagamento
        {
            get => _pedido.FormaPagamento;
            set
            {
                if (_pedido.FormaPagamento != value)
                {
                    _pedido.FormaPagamento = value;
                    OnPropertyChanged();
                }
            }
        }

        public StatusPedido Status
        {
            get => _pedido.Status;
            set
            {
                if (_pedido.Status != value)
                {
                    _pedido.Status = value;
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
