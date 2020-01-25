using Microsoft.Extensions.DependencyInjection;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.IoC.Providers.Repositories
{
    public static class RepositoryProvider
    {
        public static void Registro(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IPacienteRepository, PacienteRepository>();
        }
    }
}
