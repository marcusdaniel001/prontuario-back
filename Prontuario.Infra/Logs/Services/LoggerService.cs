using System;
using System.Collections.Generic;
using System.Text;

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
            _loggerFactory.AddConsole(LogLevel.Trace);
            var logger = _loggerFactory.CreateLogger<T>();
            logger.LogInformation("---------------- Mensagem ----------------");
            logger.LogInformation(mensagem);
            logger.LogInformation("");
            logger.LogInformation("---------------- StackTrace ----------------");
            logger.LogInformation(stackTrace);
        }
    }
}
