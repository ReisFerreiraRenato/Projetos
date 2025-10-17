using System.Windows;

namespace WpfApp.Utils
{
    public static class Mensagens
    {
        public static MessageBoxResult MensagemQuestionamento(Window janela, string mensagem, string titulo)
        {
            return MessageBox.Show(janela, mensagem, titulo, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static MessageBoxResult MensagemQuestionamento(string mensagem, string titulo)
        {
            return MessageBox.Show(mensagem, titulo, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static MessageBoxResult MensagemQuestionamentoConfirmacaoSair(string mensagem, string titulo)
        {
            return MensagemQuestionamento(mensagem, titulo);
        }

        public static MessageBoxResult MensagemQuestionamentoConfirmacaoSair(string mensagem)
        {
            return MensagemQuestionamento(mensagem, Constantes.TituloMensagemConfirmacaoSair);
        }

        public static MessageBoxResult MensagemQuestionamentoConfirmacaoSair()
        {
            return MensagemQuestionamento(Constantes.MensagemConfirmacaoSair, Constantes.TituloMensagemConfirmacaoSair);
        }

        public static MessageBoxResult MensagemQuestionamentoConfirmacaoSair(Window janela)
        {
            return MensagemQuestionamento(janela, Constantes.MensagemConfirmacaoSair, Constantes.TituloMensagemConfirmacaoSair);
        }
    }
}
