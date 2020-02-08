using Microsoft.Extensions.DependencyInjection;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.IoC.Providers.Repositories
{
    public static class RepositoryProvider
    {
        public static void Registro(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFaturistaRepository, FaturistaRepository>();
            serviceCollection.AddScoped<ILocalAtendimentoRepository, LocalAtendimentoRepository>();
            serviceCollection.AddScoped<IPacienteRepository, PacienteRepository>();
            serviceCollection.AddScoped<ISecretariaRepository, SecretariaRepository>();
            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
