using Decomposicao.Dominio;
using Decomposicao.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Composicao.Ioc
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IFatoracao), typeof(Fatoracao));

        }
    }
}
