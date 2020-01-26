using Microsoft.Extensions.Logging;
using Prontuario.Domain.Interfaces;

namespace Prontuario.Infra.Logs.Services
{
    public class LoggerService<T> : ILoggerService
    {
        private readonly ILoggerFactory _loggerFactory;

        public LoggerService()
        {
            _loggerFactory = new LoggerFactory();
        }

        public void Informar(string mensagem, string stackTrace)
        {
            var logger = _loggerFactory.CreateLogger<T>();
            logger.LogInformation("---------------- Mensagem ----------------");
            logger.LogInformation(mensagem);
            logger.LogInformation("");
            logger.LogInformation("---------------- StackTrace ----------------");
            logger.LogInformation(stackTrace);
        }
    }
}
