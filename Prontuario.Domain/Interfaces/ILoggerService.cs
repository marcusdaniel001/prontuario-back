namespace Prontuario.Domain.Interfaces
{
    public interface ILoggerService
    {
        void Informar(string mensagem, string stackTrace);
    }
}
