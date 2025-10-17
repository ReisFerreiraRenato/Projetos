using System.Windows;
using System.Windows.Input;
using WpfApp.Utils;

namespace WpfApp.ViewModels
{
    public class PrincipalViewModel : ViewModelBase
    {
        private object _currentView;

        public ICommand NavigatePessoasCommand { get; }
        public ICommand NavigateProdutosCommand { get; }
        public ICommand NavigatePedidosCommand { get; }
        public ICommand SairCommand { get; }

        // propriedade de ligação de tela
        public object CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }

        // carregar a tela inicial
        public PrincipalViewModel()
        {
            _currentView = new PedidoViewModel(new Models.Pedido());

            NavigatePedidosCommand = new DelegateCommand(o => NavigateToPedidos());
            NavigatePessoasCommand = new DelegateCommand(o => NavigateToPessoas());
            NavigateProdutosCommand = new DelegateCommand(o => NavigateToProdutos());

            SairCommand = new DelegateCommand(o => ExecuteSair());
        }

        // mudar de tela
        public void NavigateTo(object viewModel)
        {
            // Uso da propriedade para notificar a mudança
            CurrentView = viewModel;
        }

        private void NavigateToPessoas()
        {
            CurrentView = new PessoaViewModel(new Models.Pessoa());
        }

        private void NavigateToProdutos()
        {
            CurrentView = new ProdutoViewModel(new Models.Produto());
        }

        private void NavigateToPedidos()
        {
            CurrentView = new PedidoViewModel(new Models.Pedido());
        }

        private static void ExecuteSair()
        {
            Window ownerWindow = Application.Current.MainWindow;

            MessageBoxResult result = Mensagens.MensagemQuestionamentoConfirmacaoSair(ownerWindow);

            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
