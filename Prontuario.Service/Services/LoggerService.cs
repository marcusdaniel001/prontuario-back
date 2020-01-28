using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Interfaces.Services;

namespace Prontuario.Service.Services
{
    public class LoggerService : ILoggerService
    {
        public void Informar(Exception ex)
        {
            Console.WriteLine("---------------- Mensagem ----------------");
            Console.WriteLine(ex.Message);
            Console.WriteLine("---------------- StackTrace ----------------");
            Console.WriteLine(ex.StackTrace);
        }
    }
}
