using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prontuario.Service.IoC.Providers.Services;

namespace Prontuario.Service.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ApiDependencias(this IServiceCollection serviceCollection)
        {
            #region Api
            ServicoProvider.Registro(serviceCollection);
            #endregion
        }
    }
}
