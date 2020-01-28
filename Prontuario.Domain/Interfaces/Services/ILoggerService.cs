using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Interfaces.Services
{
    public interface ILoggerService
    {
        void Informar(Exception ex);
    }
}
