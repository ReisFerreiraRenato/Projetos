using WpfApp.Models;
using WpfApp.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Linq;
using System.Windows;

namespace WpfApp.ViewModels
{
    public class PedidoViewModel(Pedido pedido) : INotifyPropertyChanged
    {
        private readonly Pedido _pedido = pedido ?? throw new ArgumentNullException(nameof(pedido), Constantes.ErroPedidoNaoEncontrado);

        private int _produtoIdAdicionar;
        private int _quantidadeAdicionar = 1;
        private decimal _precoTotalItemAdicionar;
        private string _descricaoProdutoAdicionar = "N/A";
        private ItensPedido? _itemPedidoSelecionado;

        public ICommand AdicionarItemCommand { get; } = new DelegateCommand(o => ((PedidoViewModel?)o)?.AdicionarItem(), o => ((PedidoViewModel?)o)?.CanAdicionarItem() ?? false);
        public ICommand RemoverItemCommand { get; } = new DelegateCommand(o => ((PedidoViewModel?)o)?.RemoverItem(), o => ((PedidoViewModel?)o)?.CanRemoverItem() ?? false);
        public ICommand SalvarPedidoCommand { get; } = new DelegateCommand(o => ((PedidoViewModel?)o)?.SalvarPedido());

        // Construtor padrão para facilitar o design-time
        public PedidoViewModel() : this(new Pedido
        {
            Pedido_Id = 9999,
            PessoaId = 1,
            ValorTotal = 100.75m,
            DataVenda = DateTime.Now,
            // Inicialize ItensPedido para evitar NullReferenceException no ListView
            ItensPedido = []
        })
        {
            //
        }

        // ** MÉTODO AUXILIAR PARA ATUALIZAR O ESTADO DOS BOTÕES **
        private void RaiseCommandsCanExecute()
        {
            (AdicionarItemCommand as DelegateCommand)?.RaiseCanExecuteChanged();
            (RemoverItemCommand as DelegateCommand)?.RaiseCanExecuteChanged();
        }

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

        public ObservableCollection<ItensPedido> ItensPedido
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

        public ItensPedido? ItemPedidoSelecionado
        {
            get => _itemPedidoSelecionado;
            set
            {
                if (_itemPedidoSelecionado != value)
                {
                    _itemPedidoSelecionado = value;
                    OnPropertyChanged();
                    (RemoverItemCommand as DelegateCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public int ProdutoIdAdicionar
        {
            get => _produtoIdAdicionar;
            set
            {
                if (_produtoIdAdicionar != value)
                {
                    if (value <= 0)
                        throw new ArgumentException(Constantes.ErroProdutoInexistente);
                    _produtoIdAdicionar = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal PrecoTotalItemAdicionar
        {
            get => _precoTotalItemAdicionar;
            set
            {
                if (_precoTotalItemAdicionar != value)
                {
                    if (value < 0)
                        throw new ArgumentException(Constantes.ErroPrecoTotalItemInvalido);
                    _precoTotalItemAdicionar = value;
                    OnPropertyChanged();
                }
            }
        }

        public int QuantidadeAdicionar
        {
            get => _quantidadeAdicionar;
            set
            {
                if (_quantidadeAdicionar != value)
                {
                    if (value <= 0)
                        throw new ArgumentException(Constantes.ErroQuantidadeItemInvalida);
                    _quantidadeAdicionar = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DescricaoProdutoAdicionar
        {
            get => _descricaoProdutoAdicionar;
            set
            {
                if (_descricaoProdutoAdicionar != value)
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException(Constantes.ErroDescricaoObrigatoria);
                    _descricaoProdutoAdicionar = value;
                    OnPropertyChanged();
                }
            }
        }

        private void RecalcularValorTotal()
        {
            // O ValueTotal é a soma do total de cada item
            _pedido.ValorTotal = _pedido.ItensPedido.Sum(i => i.PrecoTotalItem);
            OnPropertyChanged(nameof(ValorTotal));
        }

        private bool CanAdicionarItem() => ProdutoIdAdicionar > 0 && QuantidadeAdicionar > 0;

        private void AdicionarItem()
        {
            var novoItem = new ItensPedido
            {
                ProdutoId = ProdutoIdAdicionar,
                PedidoId = _pedido.Pedido_Id,
                Quantidade = QuantidadeAdicionar,
                PrecoTotalItem = PrecoTotalItemAdicionar,
            };

            // Adiciona na ObservableCollection e o XAML se atualiza
            _pedido.ItensPedido.Add(novoItem);

            RecalcularValorTotal();

            // Limpar os campos para o próximo item
            ProdutoIdAdicionar = 0;
            QuantidadeAdicionar = 1;
        }

        private bool CanRemoverItem()
        {
            // Habilita o botão se um item estiver selecionado
            return ItemPedidoSelecionado != null;
        }

        private void SalvarPedido()
        {
            if (_pedido.ItensPedido == null || _pedido.ItensPedido.Count == 0)
            {
                MessageBox.Show("O pedido deve ter pelo menos um item.", "Erro de Validação");
                return;
            }

            MessageBox.Show($"Pedido {_pedido.Pedido_Id} salvo com sucesso! Total: {_pedido.ValorTotal:C2}", "Sucesso");
        }



        private void RemoverItem()
        {
            if (ItemPedidoSelecionado != null)
            {
                _pedido.ItensPedido.Remove(ItemPedidoSelecionado);
                RecalcularValorTotal();

                // Limpa a seleção após remover o item
                ItemPedidoSelecionado = null;
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
