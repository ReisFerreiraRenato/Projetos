using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WpfApp.Utils;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class PrincipalViewModel : INotifyPropertyChanged
    {
        private object _currentView;

        public ICommand NavigatePessoasCommand { get; }
        public ICommand NavigateProdutosCommand { get; }
        public ICommand NavigatePedidosCommand { get; }

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

            OnPropertyChanged(nameof(CurrentView));
        }

        // aviso de mudança de propriedade
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
