using System.Windows;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PrincipalView : Window
    {
        public PrincipalView()
        {
            InitializeComponent();

            DataContext = new PrincipalViewModel();
        }
    }
}