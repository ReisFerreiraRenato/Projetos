namespace WpfApp.Utils
{
    public enum FormaPagamento
    {
        Dinheiro,
        CartaoCredito,
        CartaoDebito,
        Pix,
        Boleto
    }

    public enum StatusPedido
    {
        Pendente, // Padrão
        Processando,
        Enviado,
        Entregue,
        Cancelado
    }
}
