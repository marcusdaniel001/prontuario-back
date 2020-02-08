using Microsoft.Extensions.DependencyInjection;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Service.Services;

namespace Prontuario.Service.IoC.Providers.Services
{
    public static class ServicoProvider
    {
        public static void Registro(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFaturistaService, FaturistaService>();
            serviceCollection.AddScoped<ILocalAtendimentoService, LocalAtendimentoService>();
            serviceCollection.AddScoped<ILoggerService, LoggerService>();
            serviceCollection.AddScoped<IPacienteService, PacienteService>();
            serviceCollection.AddScoped<ISecretariaService, SecretariaService>();
            serviceCollection.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
