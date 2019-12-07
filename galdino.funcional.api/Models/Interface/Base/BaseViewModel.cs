namespace galdino.funcional.api.Models.Interface.Base
{
    public class BaseViewModel<T> where T : new()
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; } = null;
        public long TempoDeProcessamento { get; set; } = 0;
        public T ObjetoDeRetorno { get; set; } = new T();
        public string Versao { get; set; }

        public void GerarRetornoErro(T objeto, string mensagem)
        {
            Mensagem = mensagem;
            Sucesso = false;
        }
    }
}
