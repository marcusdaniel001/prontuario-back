using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Service.Logs
{
    public class LogService
    {
        public static void Informar<T>(string mensagem, string stackTrace)
        {
            new LoggerService<T>().Informar(mensagem, stackTrace);
        }
    }
}
