using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Prontuario.Domain.Interfaces;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Service.Services;

namespace Prontuario.Service.IoC.Providers.Services
{
    public static class ServicoProvider
    {
        public static void Registro(IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddScoped<IPacienteService, PacienteService>();
        }
    }
}
