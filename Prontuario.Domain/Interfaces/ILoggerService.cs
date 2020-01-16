using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Interfaces
{
    public interface ILoggerService
    {
        void Informar(string mensagem, string stackTrace);
    }
}
